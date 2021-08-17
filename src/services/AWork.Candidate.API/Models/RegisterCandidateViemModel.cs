using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AWork.Identity.API.Models;

namespace AWork.Candidatos.API.Models
{
    public class RegisterCandidateViemModel : RegisterUserViewModel
    {

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
    }
}
