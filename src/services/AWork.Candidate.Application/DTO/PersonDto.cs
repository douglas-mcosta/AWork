using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class PersonDto
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("UserId")]
        public Guid UserId { get; set; }
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
        public int? IdGroupApse { get; set; }
        public Guid? IdGroupApseGuid { get; set; }
        public int? GrupoAPSeIdEmpresa { get; set; }
        public bool? DownloadPPD { get; set; }
        [DisplayName("Perfil do LinkedIn")]
        public string LinkedIn { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        public CountryDto Nationality { get; set; }
        public MaritalStatusDto MaritalStatus { get; set; }
        public SpecialNeedsDto SpecialNeeds { get; set; }
        public AddressDto Address { get; set; }
        public ReligionDto Religion { get; set; }
        public IList<PhoneDto> Phones { get; set; }
        public IList<InterviewDto> Interviews { get; set; }
        public IList<JobSubscribeDto> JobSubscribes { get; set; }
        public IList<JobTitleInterestedDto> JobTitleInteresteds { get; set; }
        public IList<LanguagePersonDto> Languages { get; set; }
        public IList<NotificationForPersonDto> Notifications { get; set; }

        public IList<ProfessionalBackgroundDto> ProfessionalBackgrounds { get; set; }
        public IList<AcademicEducationDto> AcademicEducations { get; set; }

    }

}