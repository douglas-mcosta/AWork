using System;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Notificação para o Candidato
    public class NotificationForCandidate : Entity
    {
        public NotificationForCandidate()
        {
            CreateDate = DateTime.Now;
        }
        public Guid CandidateId { get; set; }
        public Guid CreatedById { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
        public DateTime ReadDate { get; private set; }
        public bool Deleted { get; set; }
        /* EF Relation */
        public Candidate Candidate { get; set; }
    }
}