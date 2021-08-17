using System;
using AWork.Core.Messages;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.JobTitleInteresteds
{
    public class DeleteJobTitleInterestedCandidateCommand : Command
    {
        public DeleteJobTitleInterestedCandidateCommand(Guid id, Guid candidateId)
        {
            AggregateId = candidateId;
            Id = id;
            CandidateId = candidateId;
        }

        public Guid Id { get; private set; }
        public Guid CandidateId { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteJobTitleInterestedCandidateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class DeleteJobTitleInterestedCandidateCommandValidation : AbstractValidator<DeleteJobTitleInterestedCandidateCommand>
    {
        public DeleteJobTitleInterestedCandidateCommandValidation()
        {
            RuleFor(j => j.Id)
               .NotEqual(Guid.Empty).WithMessage("Cargo de interesse inválido");

            RuleFor(j => j.Id)
                .NotEqual(Guid.Empty).WithMessage("Candidato inválido");
        }
    }
}
