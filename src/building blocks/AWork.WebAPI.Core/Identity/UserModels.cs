using AWork.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Identity.API.Models
{
    public class RegisterUserViewModel
    {
        private string _cpf;
        public string CPF { get { return this._cpf.Replace(".", "").Replace("-", "").Trim(); } set { this._cpf = value.Replace(".", "").Replace("-", "").Trim(); } }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(60, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} está no formado invalido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
    public class UserTokenViewModel
    {
        public string UserId { get; set; }
        //public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<ClaimsViewModel> Claims { get; set; }
    }
    public class ClaimsViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        //[EmailAddress(ErrorMessage = "O campo {0} está no formado invalido.")]
        private string _cpf;
        public string CPF { get { return _cpf.Replace(".", "").Replace("-", ""); } set { _cpf = value; } }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
    }
    public class TokenResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiratioIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }

}
