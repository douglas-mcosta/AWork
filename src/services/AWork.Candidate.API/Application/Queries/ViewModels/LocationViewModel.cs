using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class LocationViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid EntityId { get; set; }
        public string LocalName { get; set; }
        public bool IsEnabled { get; set; }

        /* EF Relation */
        public AddressViewModel Address { get; set; }
        public EntitiesViewModel Entity { get; set; }
        public IList<JobViewModel> Jobs { get; set; }
    }
}