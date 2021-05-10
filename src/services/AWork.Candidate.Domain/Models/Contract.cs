using AWork.Core.DomainObjects;
using System;
namespace AWork.Candidates.Domain.Models
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
    }
}
