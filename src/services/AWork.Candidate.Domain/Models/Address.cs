using AWork.Core.DomainObjects;
using System;
namespace AWork.Candidates.Domain.Models
{
    //Endereço
    public class Address : Entity
    {
        public Guid CountryId { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        /*EF Relation*/
        public Country Country { get; private set; }

        protected Address() { }

        public Address(Guid id, Guid countryId, string zipCode, string district, string street, string number, string complement, string state, string city)
        {
            Id = id;
            CountryId = countryId;
            ZipCode = zipCode;
            District = district;
            Street = street;
            Number = number;
            Complement = complement;
            State = state;
            City = city;
        }

    }
}
