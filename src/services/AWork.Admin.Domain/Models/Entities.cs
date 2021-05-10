using AWork.Core.DomainObjects;
using System;
using System.Collections.Generic;
namespace AWork.Admin.Domain.Models
{
    //Entidade / Associação / União
    public class Entities : Entity
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        //EntidadePai
        public Guid? EntityChildId { get; set; }
        //Entidade Filha
        public List<Entities> EntityChild { get; set; }
        public string SiteAddress { get; set; }
        public string Alias { get; set; }
        public string SiteDomain { get; set; }
        public bool UseWebServer_GrupoAPSe { get; set; }
        public string WebServer_GrupoAPSe_user { get; set; }
        public string WebServer_GrupoAPSe_password { get; set; }
        public int? WebServer_GrupoAPSe_Id_Empresa { get; set; }
        /* EF */
        public IList<Location> Locations { get; set; }
    }
}