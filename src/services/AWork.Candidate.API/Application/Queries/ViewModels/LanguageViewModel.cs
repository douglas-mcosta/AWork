using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class LanguageViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string LanguageName { get; set; }
        /* EF */
        public IList<LanguageCandidateViewModel> Languages { get; set; }
    }
}