using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace AWork.Admin.Domain.Models
{
    public class JobRequest : Entity
    {
        public Guid JobTitleId { get; set; }
        public Guid LocationId { get; set; }
        public Guid CreatedById { get; set; }
        public int JobQuantity { get; set; }
        public int Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        /* EF */
        //public JobTitle JobTitle { get; set; }
        public Job Job { get; set; }
        //public Person CreatedBy { get; set; }
        public Location Location { get; set; }
        public IList<JobRequestStatus> JobRequestStatus { get; set; }
    }
}