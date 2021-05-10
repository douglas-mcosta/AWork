using FluentValidation;

namespace AWork.Candidates.Domain.Models.Validations
{
    public class CourseLevelValidation : AbstractValidator<CourseLevel>
    {
        public CourseLevelValidation()
        {
            RuleFor(c => c.CourseLevelName)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Length(2, 150).WithMessage("O campo {PropertyName} deve ter ente {MinLength} e {MaxLength}.");
        }
    }
}