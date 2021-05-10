using System;
using System.Collections.Generic;

namespace AWork.Identity.API.Models
{
    public class Entity
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ContactEmail { get; set; }
        //EntidadePai
        public Guid? EntityChildId { get; set; }
        //Entidade Filha
        public List<Entity> EntityChild { get; set; }
        public string SiteAddress { get; set; }
        public string SiteDomain { get; set; }

    }
}
