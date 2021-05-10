using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class PersonRegisterDto
    {
        private string _cpf;

        public PersonRegisterDto()
        {

        }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid UserId { get; set; }
        [DisplayName("Primeiro Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [DisplayName("Último Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string LastName { get; set; }
        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(300, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayName("Gênero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Gender { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CPF { get { return this._cpf.Replace(".", "").Replace("-", "").Trim(); } set { this._cpf = value.Replace(".", "").Replace("-", "").Trim(); } }
        [DisplayName("Foto de Perfil")]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }

    }
}
