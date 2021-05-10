using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class InterviewStatusDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        /* EF */
        public IList<InterviewDto> Interviews { get; set; }
    }
}