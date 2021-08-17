using System;
using AWork.Core.DomainObjects;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.Domain.Models
{
    //Telefone
    public class Phone : Entity
    {
        protected Phone() { }
        public Phone(Guid id, Guid candidateId, string phoneNumber, bool isDefault, PhoneType phoneType)
        {
            Id = id;
            CandidateId = candidateId;
            PhoneNumber = phoneNumber;
            Default = isDefault;
            PhoneType = phoneType;
        }

        public Guid CandidateId { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool Default { get; private set; }
        public PhoneType PhoneType { get; private set; }
        /* EF Relation */
        public Candidate Candidate { get; private set; }


        public bool IsNotDefault() => Default == false;
        public bool IsDefault() => Default == true;
        public void SetDefault() => Default = true;
        public void SetNotDefault() => Default = false;

        public static class PhoneFactory
        {
            public static Phone NewPhone(Guid id)
            {
                var phone = new Phone
                {
                    Id = id,
                };
                return phone;
            }
        }

    }
}
