using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class JobTitleInterestedDto
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Guid PersonId { get; set; }
        public virtual Guid JobTitleId { get; set; }
        public bool IsDefault { get; set; }
        public string JobTitleName { get; set; }
    }

    public class JobTitleInterestedRegisterDto
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Guid PersonId { get; set; }
        public virtual Guid JobTitleId { get; set; }
        public bool IsDefault { get; set; }
    }
}