using System;
using System.ComponentModel.DataAnnotations;
namespace AWork.Application.DTO
{
    public class NotificationForPersonDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
        public DateTime ReadDate { get; private set; }
        public bool Deleted { get; set; }
        /* EF Relation */
        public PersonDto Person { get; set; }
    }
}