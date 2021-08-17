using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidatos.API.Application.Queries.ViewModels
{
    public class JobViewModel
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
        public JobTitleViewModel JobTitle { get; set; }
        public LocationViewModel Local { get; set; }
        public IList<JobSubscribeDto> JobSubscribe { get; set; }
    }
}