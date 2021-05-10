using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Vagas
    public class Job : Entity
    {
        public Guid JobRequestId { get; set; }
        public Guid CreatedById { get; set; }
        public int JobQuantity { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public string Benefits { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; private set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        /* EF Relation */
        //public JobRequest JobRequest { get; set; }
        public Candidate CreatedBy { get; set; }
        public IList<JobSubscribe> JobSubscribe { get; set; }
    }
}