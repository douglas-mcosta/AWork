using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class CandidateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Nacionalidade")]
        public Guid? NationalityId { get; set; }
        [DisplayName("Estado Civil")]
        public Guid? MaritalStatusId { get; set; }
        [DisplayName("Necessidades Especiais")]
        public Guid? SpecialNeedsId { get; set; }
        [DisplayName("Endereço")]
        public Guid? AddressId { get; set; }
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
        [DisplayName("Gênero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Gender { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CPF { get; set; }
        [DisplayName("Foto de Perfil")]
        public string PhotoProfile { get; set; }
        //public IFormFile ProfileBase64Upload { get; set; }
        public bool PPD { get; set; }
        [DisplayName("Objetivo Profissional")]
        [StringLength(450, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Goal { get; set; }
        [DisplayName("Objetivo Profissional")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Summary { get; set; }
        [DisplayName("Perfil do LinkedIn")]
        public string LinkedIn { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        public CountryViewModel Nationality { get; set; }
        public MaritalStatusViewModel MaritalStatus { get; set; }
        public SpecialNeedsViewModel SpecialNeeds { get; set; }
        public AddressViewModel Address { get; set; }
        public ReligionViewModel Religion { get; set; }
        public IList<PhoneViewModel> Phones { get; set; }
        public IList<InterviewViewModel> Interviews { get; set; }
        public IList<JobSubscribeDto> JobSubscribes { get; set; }
        public IList<JobTitleInterestedDto> JobTitleInteresteds { get; set; }
        public IList<LanguageCandidateViewModel> Languages { get; set; }
        public IList<NotificationForCandidateViewModel> Notifications { get; set; }

        public IList<ProfessionalBackgroundViewModel> ProfessionalBackgrounds { get; set; }
        public IList<AcademicEducationViewModel> AcademicEducations { get; set; }

    }

}