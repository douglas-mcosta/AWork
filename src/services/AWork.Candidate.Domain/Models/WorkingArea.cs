using AWork.Core.DomainObjects;
using System.Collections.Generic;
namespace AWork.Candidates.Domain.Models
{
    //Area de Atuação
    public class WorkingArea : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<ProfessionalBackground> ProfessionalBackgrounds { get; set; }
    }
}