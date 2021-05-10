using System;
using System.ComponentModel.DataAnnotations;
namespace AWork.Application.DTO
{
    public class AddressDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CountryId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string District { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Number { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Complement { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(70, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(70, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string City { get; set; }
        public string CountryName { get; set; }
    }
    public class AddressRegisterDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CountryId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string District { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Number { get; set; }
        [StringLength(200, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Complement { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(70, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(70, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string City { get; set; }
    }
}