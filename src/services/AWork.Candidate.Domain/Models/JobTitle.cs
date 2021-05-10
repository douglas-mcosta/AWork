using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Cargo
    public class JobTitle : Entity
    {
        protected JobTitle() { }
        public JobTitle(Guid? jobTitleId, string name)
        {
            JobTitleId = jobTitleId;
            Name = name;
        }

        public Guid? JobTitleId { get; private set; }
        public string Name { get; private set; }
        public bool Hidden { get; private set; }
     
        /* EF Relation */
        public JobTitle JobTitleParent { get; private set; }
        public IList<JobTitle> JobTitleChild { get; private set; }
        public IList<JobTitleInterested> JobTitleInteresteds { get; private set; }
    }
}