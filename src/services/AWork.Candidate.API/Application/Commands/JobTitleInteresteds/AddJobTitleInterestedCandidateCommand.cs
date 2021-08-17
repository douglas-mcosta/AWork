using System;
using AWork.Core.Messages;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.JobTitleInteresteds
{
    public class AddJobTitleInterestedCandidateCommand : Command
    {
        public AddJobTitleInterestedCandidateCommand(Guid jobTitleId, Guid candidateId, bool isDefault)
        {
            AggregateId = candidateId;
            JobTitleId = jobTitleId;
            CandidateId = candidateId;
            IsDefault = isDefault;
        }

        public Guid JobTitleInterestedId { get; private set; }
        public Guid JobTitleId { get; private set; }
        public Guid CandidateId { get; private set; }
        public bool IsDefault { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AddJobTitleInterestedValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddJobTitleInterestedValidation : AbstractValidator<AddJobTitleInterestedCandidateCommand>
    {
        public AddJobTitleInterestedValidation()
        {
            RuleFor(j => j.JobTitleId)
           .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
            RuleFor(j => j.CandidateId)
           .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}
