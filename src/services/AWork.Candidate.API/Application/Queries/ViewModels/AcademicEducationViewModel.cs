using System;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class AcademicEducationViewModel
    {
        public Guid CandidateId { get; set; }
        public Guid CourseId { get; set; }
        public int CourseStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string College { get; set; }
        public string CustomCourse { get; set; }
        public string Course { get; set; }
    }
}