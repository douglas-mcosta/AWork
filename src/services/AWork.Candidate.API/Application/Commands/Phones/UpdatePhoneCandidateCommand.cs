using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.Phones
{
    public class UpdatePhoneCandidateCommand : Command
    {
        public Guid PhoneId { get; private set; }
        public Guid CandidateId { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsDefault { get; private set; }
        public PhoneType PhoneType { get; private set; }

        public UpdatePhoneCandidateCommand(Guid phoneId,Guid candidateId, string phoneNumber, bool isDefault, PhoneType phoneType)
        {
            AggregateId = candidateId;
            PhoneId = phoneId;
            CandidateId = candidateId;
            PhoneNumber = phoneNumber;
            IsDefault = isDefault;
            PhoneType = phoneType;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePhoneCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdatePhoneCandidateValidation : AbstractValidator<UpdatePhoneCandidateCommand>
    {
        public UpdatePhoneCandidateValidation()
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
