using AWork.Core.DomainObjects.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AWork.Candidates.API.Application.Queries.ViewModels
{
    public class LanguageCandidateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid LanguageId { get; set; }
        public virtual FluencyLevel FluencyLevel { get; set; }
        public string LanguageName { get; set; }
    }
    public class LanguageCandidateRegisterDto
    {
        [Key]
        public Guid Id{ get; set; }
        public Guid CandidateId { get; set; }
        public Guid LanguageId { get; set; }
        public virtual FluencyLevel FluencyLevel { get; set; }
    }
}