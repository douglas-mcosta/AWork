using AWork.Core.DomainObjects.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class LanguagePersonDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid LanguageId { get; set; }
        public virtual FluencyLevel FluencyLevel { get; set; }
        public string LanguageName { get; set; }
    }
    public class LanguagePersonRegisterDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid LanguageId { get; set; }
        public virtual FluencyLevel FluencyLevel { get; set; }
    }
}