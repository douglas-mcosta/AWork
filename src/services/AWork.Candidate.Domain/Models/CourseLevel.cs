using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Nivel do Curso
    public class CourseLevel : Entity
    {
        protected CourseLevel() { }
       
        public CourseLevel(string courseLevelName)
        {
            CourseLevelName = courseLevelName;
        }

        public string CourseLevelName { get; private set; }
        /*EF Relation*/
        public IList<Course> Course { get; private set; }
    }
}