using AWork.Candidates.Domain.Models;
using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Curso
    public class Course : Entity
    {
        protected Course() { }
        public Course(Guid courseLevelId, string courseName)
        {
            CourseLevelId = courseLevelId;
            CourseName = courseName;
        }

        public Guid CourseLevelId { get; private set; }
        public string CourseName { get; private set; }
        /* EF Relation */
        public CourseLevel CourseLevel { get; private set; }
        public IList<AcademicEducation> AcademicEducations { get; private set; }

    }
}