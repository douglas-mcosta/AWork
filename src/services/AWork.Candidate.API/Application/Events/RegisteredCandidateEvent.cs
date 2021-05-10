using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using System;

namespace AWork.Candidates.API.Application.Events
{
    public class RegisteredCandidateEvent : Event
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        public RegisteredCandidateEvent(Guid id, string cpf, string firstName, string lastName, string email, DateTime birthDate, Gender gender)
        {
            Id = id;
            CPF = cpf;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
}
