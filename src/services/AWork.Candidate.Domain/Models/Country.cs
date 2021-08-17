using System.Collections.Generic;
using AWork.Core.DomainObjects;

namespace AWork.Candidatos.Domain.Models
{
    //Pais
    public class Country : Entity
    {
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public IList<Address> Address { get; private set; }

        public Country() { }

        public Country(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }
    }
}