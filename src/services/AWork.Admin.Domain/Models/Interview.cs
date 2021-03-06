using AWork.Core.DomainObjects;
using System;
namespace AWork.Admin.Domain.Models
{
    //Entrevista
    public class Interview : Entity
    {
        public Guid InterviewStatusId { get; set; }
        public Guid InterviewsScheduleId { get; set; }
        public string IndicationName { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        /* EF Relation */
        public InterviewsSchedule InterviewsSchedule { get; set; }
        //public InterviewStatus InterviewStatus { get; set; }
        public Contract Contract { get; set; }
    }
}