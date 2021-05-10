using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AWork.WebAPI.Core.Identity
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            //JWT - Pegando Config 
            var tokenSection = configuration.GetSection("Token");
            services.Configure<Token>(tokenSection);

            //Encode da Chave
            var setting = tokenSection.Get<Token>();
            var key = Encoding.ASCII.GetBytes(setting.Secret);

            //Configurando a Autenticação
            services.AddAuthentication(auth =>
            {

                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(auth =>
            {
                auth.RequireHttpsMetadata = true;
                auth.SaveToken = true;
                auth.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = setting.Audience,
                    ValidIssuer = setting.Issuer
                };
            });
            return services;
        }
        public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }

    }
}
