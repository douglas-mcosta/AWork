using System;
using AWork.Core.DomainObjects;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.Domain.Models
{
    //Formação Academica
    public class AcademicEducation : Entity
    {
        public Guid CandidateId { get; set; }
        public Guid CourseId { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string College { get; set; }
        public string CustomCourse { get; set; }
        /*EF Relation*/
        public Candidate Candidate { get; set; }
        public Course Course { get; set; }
    }
}