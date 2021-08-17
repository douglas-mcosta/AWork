using System;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;

namespace AWork.Candidatos.API.Application.Events.Phones
{
    public class AddPhoneCandidateEvent : Event
    {
        public Guid PhoneId { get; private set; }
        public Guid CandidateId { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsDefault { get; private set; }
        public PhoneType PhoneType { get; private set; }

        public AddPhoneCandidateEvent(Guid phoneId, Guid candidateId, string phoneNumber, bool isDefault, PhoneType phoneType)
        {
            AggregateId = candidateId;
            PhoneId = phoneId;
            CandidateId = candidateId;
            PhoneNumber = phoneNumber;
            IsDefault = isDefault;
            PhoneType = phoneType;
        }
    }
}
