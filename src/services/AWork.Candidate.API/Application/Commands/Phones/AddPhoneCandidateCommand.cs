using System;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.Phones
{
    public class AddPhoneCandidateCommand : Command
    {
        public Guid PhoneId { get; private set; }
        public Guid CandidateId { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsDefault { get; private set; }
        public PhoneType PhoneType { get; private set; }

        public AddPhoneCandidateCommand(Guid candidateId, string phoneNumber, bool isDefault, PhoneType phoneType)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            PhoneNumber = phoneNumber;
            IsDefault = isDefault;
            PhoneType = phoneType;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddPhoneCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddPhoneCandidateValidation : AbstractValidator<AddPhoneCandidateCommand>
    {
        public AddPhoneCandidateValidation()
        {
            {
                When(p => p.PhoneType == PhoneType.CellPhone, () =>
                {
                    RuleFor(p => p.PhoneNumber)
                    .NotEmpty()
                    .Length(11).WithMessage("O campo Celular deve conter {MaxLength} caracteres.");
                });

                When(p => p.PhoneType == PhoneType.HomePhone, () =>
                {
                    RuleFor(p => p.PhoneNumber)
                      .NotEmpty()
                      .Length(10).WithMessage("O campo Telefone Residencial deve conter {MaxLength} caracteres.");
                });
            }
        }
    }
}
