using System;

namespace AWork.Application.DTO
{
    public class AcademicEducationDto
    {
        public Guid PersonId { get; set; }
        public Guid CourseId { get; set; }
        public int CourseStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string College { get; set; }
        public string CustomCourse { get; set; }
        public string Course { get; set; }
    }
}