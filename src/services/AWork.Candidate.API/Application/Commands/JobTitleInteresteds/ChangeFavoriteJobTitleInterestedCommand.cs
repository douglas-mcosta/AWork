using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.JobTitleInteresteds
{
    public class ChangeFavoriteJobTitleInterestedCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid CandidateId { get; private set; }

        public ChangeFavoriteJobTitleInterestedCommand(Guid id, Guid candidateId)
        {
            AggregateId = candidateId;
            Id = id;
            CandidateId = candidateId;
        }

        public override bool IsValid()
        {
            ValidationResult = new ChangeFavoriteJobTitleInterestedCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ChangeFavoriteJobTitleInterestedCommandValidation : AbstractValidator<ChangeFavoriteJobTitleInterestedCommand>
    {
        public ChangeFavoriteJobTitleInterestedCommandValidation()
        {
            RuleFor(j => j.Id)
                .NotEqual(Guid.Empty).WithMessage("Cargo de interesse inválido");
            
            RuleFor(j => j.Id)
                .NotEqual(Guid.Empty).WithMessage("Candidato inválido");
        }
    }
}
