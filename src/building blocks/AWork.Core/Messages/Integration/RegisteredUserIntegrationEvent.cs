using AWork.Core.DomainObjects.Enums;
using System;

namespace AWork.Core.Messages.Integration
{
    public class RegisteredUserIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; set; }

        public RegisteredUserIntegrationEvent(Guid id, string Cpf, string firstName, string lastName, string email, DateTime birthDate, Gender gender)
        {
            Id = id;
            AggregateId = id;
            CPF = Cpf;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
}
