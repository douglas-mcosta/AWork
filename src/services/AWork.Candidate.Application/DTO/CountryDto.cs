using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class CountryDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nationality { get; set; }
    }
}