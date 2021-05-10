using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.CandidateData
{
    public class UpdateSummaryCandidateCommand : Command
    {
        public Guid CandidateId { get; private set; }
        public string Summary { get; private set; }

        public UpdateSummaryCandidateCommand(Guid candidateId, string summary)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            Summary = summary;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditSummaryCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class EditSummaryCandidateValidation : AbstractValidator<UpdateSummaryCandidateCommand>
    {
        public EditSummaryCandidateValidation()
        {
            RuleFor(p => p.Summary)
               .Length(5, 500).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}");
        }
    }
}
