using AWork.Core.DomainObjects.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class PhoneViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string PhoneNumber { get; set; }
        [DisplayName("Padrão?")]
        public bool IsDefault { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public PhoneType PhoneType { get; set; }
    }

}