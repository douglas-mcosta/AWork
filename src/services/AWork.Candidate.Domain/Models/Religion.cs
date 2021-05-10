using AWork.Core.DomainObjects;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Religião
    public class Religion : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<Candidate> Candidates { get; set; }
    }
}