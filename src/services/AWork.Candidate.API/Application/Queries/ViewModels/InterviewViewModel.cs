using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class InterviewViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CandidateId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid InterviewStatusId { get; set; }
        [DisplayName("Indicado Por")]
        public string IndicationName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data da Entrevista")]
        public DateTime DataInterview { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(500, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        /* EF Relation */
        public CandidateViewModel Candidate { get; set; }
        public InterviewStatusDto InterviewStatus { get; set; }
        public EntitiesViewModel Entity { get; set; }
    }
}