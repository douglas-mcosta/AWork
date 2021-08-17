using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Religião
    public class Religion : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<Candidate> Candidates { get; set; }
    }
}