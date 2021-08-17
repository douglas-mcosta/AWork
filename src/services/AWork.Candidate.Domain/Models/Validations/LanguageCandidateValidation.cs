using FluentValidation;

namespace AWork.Candidatos.Domain.Models.Validations
{
    public class LanguageCandidateValidation : AbstractValidator<LanguageCandidate>
    {
        public LanguageCandidateValidation()
        {
            RuleFor(lang => lang.LanguageId)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(lang => lang.FluencyLevel)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(lang => lang.CandidateId)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}