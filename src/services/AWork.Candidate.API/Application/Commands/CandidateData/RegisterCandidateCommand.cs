using AWork.Core.DomainObjects;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.CandidateData
{
    public class RegisterCandidateCommand : Command
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        public RegisterCandidateCommand(Guid id, string cpf, string firstName, string lastName, string email, DateTime birthDate, Gender gender)
        {
            AggregateId = id;
            Id = id;
            CPF = cpf;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCandidateCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class RegisterCandidateCommandValidation : AbstractValidator<RegisterCandidateCommand>
    {
        public RegisterCandidateCommandValidation()
        {
            RuleFor(p => p.BirthDate)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
               .GreaterThan(new System.DateTime(1900, 01, 01)).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.")
               .When(p => (p.BirthDate.Year - DateTime.Now.Year < 14)).WithMessage("O candidato não tem a idade minima.");

            RuleFor(p => p.CPF)
                .Must(HasCpfValid)
                .WithMessage("O Documento é invalido");
            
            RuleFor(p => p.Email)
                .Must(HasEmailValid)
                .WithMessage("O E-mail é invalido");


            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado")
                .Length(3, 100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado")
                .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");
        }

        private static bool HasCpfValid(string cpf)
        {
            return Cpf.Validate(cpf);
        }

        private static bool HasEmailValid(string cpf)
        {
            return Email.Validar(cpf);
        }
    }
}
