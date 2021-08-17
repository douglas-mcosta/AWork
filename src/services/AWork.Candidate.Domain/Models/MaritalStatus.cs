using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Estado Civil
    public class MaritalStatus : Entity
    {
        public string Name { get; private set; }
        /* EF */
        public IList<Candidate> Candidates { get; private set; }

        protected MaritalStatus() { }

        public MaritalStatus(string name)
        {
            Name = name;
        }
    }
}