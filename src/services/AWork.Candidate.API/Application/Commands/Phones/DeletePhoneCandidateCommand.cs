using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.Phones
{
    public class DeletePhoneCandidateCommand : Command
    {
        public DeletePhoneCandidateCommand(Guid candidateId, Guid phoneId)
        {
            AggregateId = CandidateId;
            CandidateId = candidateId;
            PhoneId = phoneId;
        }

        public Guid CandidateId { get; set; }
        public Guid PhoneId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeletePhoneCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class DeletePhoneCandidateValidation : AbstractValidator<DeletePhoneCandidateCommand>
    {
        public DeletePhoneCandidateValidation()
        {
            RuleFor(p => p.CandidateId)
                .NotEqual(Guid.Empty).WithMessage("O Id {PropertyName} não pode ser um Guid vazio.");

            RuleFor(p => p.PhoneId)
                .NotEqual(Guid.Empty).WithMessage("O Id {PropertyName} não pode ser um Guid vazio.");
        }
    }
}
