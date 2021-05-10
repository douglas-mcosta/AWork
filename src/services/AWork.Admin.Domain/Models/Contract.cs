using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;
namespace AWork.Admin.Domain.Models
{
    public class Contract : Entity
    {
        public Guid InterviewId { get; set; }
        public string Benefits { get; set; }
        public double Salary { get; set; }
        public TimeSpan WorkingHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedDate { get; set; }
        /* EF */
        public Interview Interview { get; set; }
        public IList<ContractRequest> ContractRequests { get; set; }
    }
}
