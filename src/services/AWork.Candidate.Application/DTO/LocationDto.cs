using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class LocationDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid EntityId { get; set; }
        public string LocalName { get; set; }
        public bool IsEnabled { get; set; }

        /* EF Relation */
        public AddressDto Address { get; set; }
        public EntitiesDto Entity { get; set; }
        public IList<JobDto> Jobs { get; set; }
    }
}