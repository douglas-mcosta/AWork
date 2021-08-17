using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Area de Atuação
    public class WorkingArea : Entity
    {
        public string Name { get; set; }
        /* EF */
        public IList<ProfessionalBackground> ProfessionalBackgrounds { get; set; }
    }
}