using AWork.Core.DomainObjects;
using System;
namespace AWork.Admin.Domain.Models
{
    public class InterviewsSchedule : Entity
    {
        public Guid JobSubscribeId { get; set; }
        public Guid LocationId { get; set; }
        public Guid CreatedBy { get; set; }
        //public EInterviewType Type { get; set; }
        public string Link { get; set; }
        //public EInterviewVia Via { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        /* EF */
        public Interview Interview { get; set; }
        //public JobSubscribe JobSubscribe { get; set; }
        public Location Location { get; set; }

    }
}
