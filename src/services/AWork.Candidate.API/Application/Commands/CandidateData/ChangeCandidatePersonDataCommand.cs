using System;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.CandidateData
{
    public class ChangeCandidatePersonDataCommand : Command
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

        public ChangeCandidatePersonDataCommand(Guid candidateId, string firstName, string lastName, DateTime birthDate,
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

        public override bool IsValid()
        {
            ValidationResult = new CandidatePersonDataValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CandidatePersonDataValidation : AbstractValidator<ChangeCandidatePersonDataCommand>
    {
        public CandidatePersonDataValidation()
        {

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado")
                .Length(3, 100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado")
                .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.BirthDate)
                 .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                 .GreaterThan(new DateTime(1900, 01, 01)).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.")
                 .When(p => p.BirthDate.Year - DateTime.Now.Year < 14).WithMessage("O candidato não tem a idade minima.");

        }
    }
}
