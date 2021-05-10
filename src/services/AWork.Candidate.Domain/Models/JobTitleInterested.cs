using AWork.Core.DomainObjects;
using System;

namespace AWork.Candidates.Domain.Models
{
    //Cargo de Interesse
    public class JobTitleInterested : Entity
    {
        protected JobTitleInterested() { }
        public JobTitleInterested(Guid candidateId, Guid jobTitleId, bool isDefault)
        {
            CandidateId = candidateId;
            JobTitleId = jobTitleId;
            IsDefault = isDefault;
        }

        public virtual Guid CandidateId { get; private set; }
        public virtual Guid JobTitleId { get; private set; }
        public bool IsDefault { get; private set; }

        /* EF Relation */
        public Candidate Candidate { get; private set; }
        public JobTitle JobTitle { get; private set; }

        public void SetDefault() => IsDefault = true;
        public void SetNotDefault() => IsDefault = false;
        public void ChangeJobTitle(Guid jobTitleId)
        {
            JobTitleId = jobTitleId;
        }
    }
}