using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using System;

namespace AWork.Candidates.API.Application.Events
{
    public class ChangeCandidatePersonDataEvent : Event
    {
        public Guid CandidateId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public Guid? MaritalStatusId { get; private set; }
        public Guid? NationalityId { get; private set; }
        public Guid? SpecialNeedsId { get; private set; }
        public Guid? ReligionId { get; private set; }

        public ChangeCandidatePersonDataEvent(Guid candidateId, string firstName, string lastName, DateTime birthDate,
                                          Gender gender, Guid? maritalStatusId,
                                          Guid? nationalityId, Guid? specialNeedsId, Guid? religionId)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            MaritalStatusId = maritalStatusId;
            NationalityId = nationalityId;
            SpecialNeedsId = specialNeedsId;
            ReligionId = religionId;
        }
    }
}
