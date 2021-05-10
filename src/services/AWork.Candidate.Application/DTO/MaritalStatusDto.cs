using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class MaritalStatusDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}