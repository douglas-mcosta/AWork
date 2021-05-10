using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWork.Application.DTO
{
    public class EntitiesDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public Guid? EntityChildId { get; set; }
        //Entidade Filha
        public List<EntitiesDto> EntityChild { get; set; }
        public string SiteAddress { get; set; }
        public string Alias { get; set; }
        public string SiteDomain { get; set; }
        public bool UseWebServer_GrupoAPSe { get; set; }
        public string WebServer_GrupoAPSe_user { get; set; }
        public string WebServer_GrupoAPSe_password { get; set; }
        public int? WebServer_GrupoAPSe_Id_Empresa { get; set; }
        /* EF */
        public IList<LocationDto> Locations { get; set; }
    }
}