using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class JobDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid LocalId { get; set; }
        public int JobQuantity { get; set; }
        public string JobDescription { get; set; }
        public string Requirement { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; private set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }

        /* EF Relation */
        public JobTitleDto JobTitle { get; set; }
        public LocationDto Local { get; set; }
        public IList<JobSubscribeDto> JobSubscribe { get; set; }
    }
}