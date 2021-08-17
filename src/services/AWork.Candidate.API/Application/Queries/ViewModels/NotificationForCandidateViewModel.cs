using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class NotificationForCandidateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
        public DateTime ReadDate { get; private set; }
        public bool Deleted { get; set; }
        /* EF Relation */
        public CandidateViewModel Candidate { get; set; }
    }
}