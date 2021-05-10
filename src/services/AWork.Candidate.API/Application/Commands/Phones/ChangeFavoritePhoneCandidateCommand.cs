using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.Phones
{
    public class ChangeFavoritePhoneCandidateCommand : Command
    {

        public Guid CandidateId { get; private set; }
        public Guid PhoneId { get; private set; }
        public ChangeFavoritePhoneCandidateCommand(Guid candidateId, Guid phoneId)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            PhoneId = phoneId;
        }
        public override bool IsValid()
        {
            ValidationResult = new ChangeFavoritePhoneCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }


    }
    public class ChangeFavoritePhoneCandidateValidation : AbstractValidator<ChangeFavoritePhoneCandidateCommand>
    {
        public ChangeFavoritePhoneCandidateValidation()
        {
            RuleFor(p => p.CandidateId)
                .NotEmpty().WithMessage("CandidateId invalido.")
                .NotEqual(Guid.Empty).WithMessage("CandidateId invalido.");

            RuleFor(p => p.PhoneId)
                .NotEmpty().WithMessage("PhoneId invalido.")
                .NotEqual(Guid.Empty).WithMessage("CandidateId invalido.");
        }
    }

}
