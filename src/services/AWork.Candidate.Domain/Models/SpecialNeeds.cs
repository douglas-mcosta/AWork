using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Necessidades Especiais
    public class SpecialNeeds : Entity
    {
        public string Name { get; private set; }
        /* EF */
        public IList<Candidate> Candidates { get; private set; }

        protected SpecialNeeds() { }

        public SpecialNeeds(string name)
        {
            Name = name;
        }
    }
}