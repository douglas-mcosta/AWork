using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class PersonDataDto
    {

        [Key]
        public Guid Id { get; set; }
        [DisplayName("Nacionalidade")]
        public Guid? NationalityId { get; set; }
        [DisplayName("Estado Civil")]
        public Guid? MaritalStatusId { get; set; }
        [DisplayName("Necessidades Especiais")]
        public Guid? SpecialNeedsId { get; set; }

        [DisplayName("Religião")]
        public Guid? ReligionId { get; set; }
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
        [DisplayName("Genero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Gender { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CPF { get; set; }
        public string Linkedin { get; set; }

    }
}