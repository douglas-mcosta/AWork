using AWork.Candidates.Domain.Interfaces;
using AWork.Core.Communication.Mediator;
using AWork.Core.Messages.Integration;
using AWork.Identity.API.Data;
using AWork.Identity.API.Models;
using AWork.MessageBus;
using AWork.WebAPI.Core.Controllers;
using AWork.WebAPI.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Identity.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : MainController
    {
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Token _appSettings;
        private readonly IMessageBus _bus;

        public AuthController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                IOptions<Token> appSettings,
                                IdentityContext context,                                
                                IMessageBus bus)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
            _context = context;
            _bus = bus;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var user = new ApplicationUser
            {
                FirstName = registerUserViewModel.FirstName,
                LastName = registerUserViewModel.LastName,
                Email = registerUserViewModel.Email,
                EmailConfirmed = true,
                UserName = registerUserViewModel.CPF
            };

            var hasUserWithEmail = await _userManager.FindByEmailAsync(registerUserViewModel.Email) != null;
            if (hasUserWithEmail)
            {
                NotifierError("Já existe um usuário com esse email cadastrado");
                return CustomResponse();
            }

            var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);
            if (result.Succeeded)
            {
                var candidateResult = await RegisterCandidate(registerUserViewModel);
                if (!candidateResult.ValidationResult.IsValid)
                {
                    await _userManager.DeleteAsync(user);
                    return CustomResponse(candidateResult.ValidationResult);
                }
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(registerUserViewModel.CPF));
            }
            else
            {
                foreach (var erro in result.Errors)
                {
                    NotifierError(erro.Description);
                }
            }

            return CustomResponse(registerUserViewModel);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.CPF, loginViewModel.Password, false, true);
            if (result.Succeeded)
                return CustomResponse(await GerarJwt(loginViewModel.CPF));
            if (result.IsLockedOut)
            {

                NotifierError("Usuário bloqueado.Tente novamente mais tarde.");
                return CustomResponse(loginViewModel);
            }
            NotifierError("Usuário ou senha invalida.");
            return CustomResponse(loginViewModel);
        }

        private async Task<TokenResponseViewModel> GerarJwt(string cpf)
        {
            var user = await _userManager.FindByNameAsync(cpf);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await GetClaimsUser(user, claims);
            var encodedToken = WriteToken(identityClaims);

            return TokenReponse(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> GetClaimsUser(ApplicationUser user, ICollection<Claim> claims)
        {

            //Pegando role do usuário
            var roles = await _userManager.GetRolesAsync(user);
            var roleId = _context.Roles.FirstOrDefault(x => roles.Contains(x.Name))?.Id;
            //Pegando todos os claims dessa role
            var roleClaims = _context.RoleClaims.Where(x => x.RoleId == roleId).ToList();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in roles)
            {
                claims.Add(new Claim("role", userRole));
            }
            var teste = new List<Guid>();
            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;

        }

        private string WriteToken(ClaimsIdentity identityClaims)
        {

            //Para manipular o token
            var tokenHandle = new JwtSecurityTokenHandler();
            //Key
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //Gerar o token
            var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            //Escrever o token. Serializar no padrão da web
            var encodedToken = tokenHandle.WriteToken(token);
            return encodedToken;
        }

        private TokenResponseViewModel TokenReponse(string encodedToken, ApplicationUser user, ICollection<Claim> claims)
        {

            var filtro = new List<string>(){
                new string("sub"),
                new string("jti"),
                new string("nbf"),
                new string("iat"),
                new string("iss"),
                new string("aud"),
                new string("email"),
            };
            return new TokenResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiratioIn = TimeSpan.FromHours(_appSettings.ExpirationInHours).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    FirstName = user.FirstName,
                    //UserName = user.UserName,
                    Email = user.Email,
                    UserId = user.Id,
                    Claims = claims.Select(x => new ClaimsViewModel { Type = x.Type, Value = x.Value }).Where(x => !filtro.Contains(x.Type))
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private async Task<ResponseMessage> RegisterCandidate(RegisterUserViewModel userRegister)
        {
            var user = await _userManager.FindByEmailAsync(userRegister.Email);
            var RegisteredUser = new RegisteredUserIntegrationEvent(Guid.Parse(user.Id),
                                                                    userRegister.CPF,
                                                                    userRegister.FirstName,
                                                                    userRegister.LastName,
                                                                    userRegister.Email,
                                                                    userRegister.BirthDate,
                                                                    userRegister.Gender);
            try
            {
                return await _bus.RequestAsync<RegisteredUserIntegrationEvent, ResponseMessage>(RegisteredUser);
            }
            catch
            {
                await _userManager.DeleteAsync(user);
                NotifierError("Erro ao criar candidato.");
                throw;
            }
        }



    }
}
