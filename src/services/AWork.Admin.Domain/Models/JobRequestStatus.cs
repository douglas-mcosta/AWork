using AWork.Core.DomainObjects;
using System;
namespace AWork.Admin.Domain.Models
{
    public class JobRequestStatus : Entity
    {
        public Guid JobRequestId { get; set; }
        public Guid AnalyzedById { get; set; }
        //public EJobRequestStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        /* EF */
        public JobRequest JobRequest { get; set; }
        //public Person AnalyzedBy { get; set; }
    }
}
