using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class JobSubscribeDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid JobId { get; set; }
        public DateTime CreatedDate { get; set; }
        /* EF Relation */
        public CandidateViewModel Candidate { get; set; }
        public JobViewModel Job { get; set; }
    }
}