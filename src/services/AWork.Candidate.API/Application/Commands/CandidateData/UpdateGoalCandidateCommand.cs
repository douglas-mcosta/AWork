using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.CandidateData
{
    public class UpdateGoalCandidateCommand : Command
    {
        public Guid CandidateId { get; private set; }
        public string Goal { get; private set; }

        public UpdateGoalCandidateCommand(Guid candidateId, string goal)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            Goal = goal;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditCandidateGoalValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class EditCandidateGoalValidation : AbstractValidator<UpdateGoalCandidateCommand>
    {
        public EditCandidateGoalValidation()
        {
            RuleFor(p => p.CandidateId)
                .NotEqual(Guid.Empty).WithMessage("O Id da pessoa é invalido.")
                .NotEmpty().WithMessage("O Id da Pessoa é obrigatorio.");

            RuleFor(g => g.Goal)
                .Length(5, 500).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}");
        }
    }

}
