using AWork.Core.DomainObjects;
using System;
namespace AWork.Admin.Domain.Models
{
    //Sincronizar com APS para verificar se o funcionario ja trabalho na rede
    public class SyncAPS : Entity
    {
        public string CPF { get; set; }
        public string Entity { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public string Status { get; set; }
        public string Abbreviation { get; set; }
    }
}