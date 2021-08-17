using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class CandidateEditDto
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
        public string FullName { get { return FirstName + " " + LastName; } }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayName("Genero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Gender Gender { get; set; }
        public string LinkedIn { get; set; }

    }
}