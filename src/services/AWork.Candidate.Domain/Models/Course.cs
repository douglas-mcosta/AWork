using System;
using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
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