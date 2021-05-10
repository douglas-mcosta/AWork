using AWork.Core.DomainObjects;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Idioma
    public class Language : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<LanguageCandidate> Languages { get; set; }
    }
}