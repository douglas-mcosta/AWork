using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class InterviewStatusDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        /* EF */
        public IList<InterviewViewModel> Interviews { get; set; }
    }
}