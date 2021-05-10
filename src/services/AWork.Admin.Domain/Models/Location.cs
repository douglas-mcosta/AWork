using AWork.Core.DomainObjects;
using System;
namespace AWork.Admin.Domain.Models
{
    //Local 
    public class Location : Entity
    {
        public Guid AddressId { get; set; }
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        /* EF Relation */
        //public Address Address { get; set; }
        //public Entities Entity { get; set; }
        // public IList<Job> Jobs { get; set; }
        public JobRequest JobRequest { get; set; }
        public InterviewsSchedule InterviewsSchedule { get; set; }
    }
}