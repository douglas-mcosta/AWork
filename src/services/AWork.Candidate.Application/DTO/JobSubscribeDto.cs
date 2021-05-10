using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class JobSubscribeDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid JobId { get; set; }
        public DateTime CreatedDate { get; set; }
        /* EF Relation */
        public PersonDto Person { get; set; }
        public JobDto Job { get; set; }
    }
}