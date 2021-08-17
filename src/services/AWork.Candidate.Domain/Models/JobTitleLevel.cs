using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
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