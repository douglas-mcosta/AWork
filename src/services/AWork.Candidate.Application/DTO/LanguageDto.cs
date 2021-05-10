using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AWork.Application.DTO
{
    public class LanguageDto
    {
        [Key]
        public Guid Id { get; set; }
        public string LanguageName { get; set; }
        /* EF */
        public IList<LanguagePersonDto> Languages { get; set; }
    }
}