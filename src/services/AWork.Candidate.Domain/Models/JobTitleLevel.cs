using AWork.Core.DomainObjects;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Nível do cargo
    public class JobTitleLevel : Entity
    {
        protected JobTitleLevel() { }
        public string Level { get; private set; }

        public JobTitleLevel(string level)
        {
            Level = level;
        }

        /* EF */
        public IList<ProfessionalBackground> ProfessionalBackgrounds { get; private set; }
    }
}