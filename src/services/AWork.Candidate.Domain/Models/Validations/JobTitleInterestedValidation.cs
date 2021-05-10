using FluentValidation;

namespace AWork.Candidates.Domain.Models.Validations
{
    public class JobTitleInterestedValidation : AbstractValidator<JobTitleInterested>
    {
        public JobTitleInterestedValidation()
        {
            RuleFor(j => j.JobTitleId)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
            RuleFor(j => j.CandidateId)
           .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}
