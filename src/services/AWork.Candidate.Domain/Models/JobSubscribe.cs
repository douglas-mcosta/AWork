using AWork.Core.DomainObjects;
using System;

namespace AWork.Candidates.Domain.Models
{
    //Vaga de Interesse do Candidato
    //Alterado JobInterested de para JobSubscribe
    public class JobSubscribe : Entity
    {
        public Guid CandidateId { get; set; }
        public Guid JobId { get; set; }
        public DateTime CreatedDate { get; set; }
        /* EF Relation */
        public Candidate Candidate { get; set; }
        public Job Job { get; set; }
    }
}