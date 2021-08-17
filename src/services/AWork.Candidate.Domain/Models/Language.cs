using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Idioma
    public class Language : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<LanguageCandidate> Languages { get; set; }
    }
}