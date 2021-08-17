using FluentValidation;

namespace AWork.Candidatos.Domain.Models.Validations
{
    public class CourseValidation : AbstractValidator<Course>
    {
        public CourseValidation()
        {
            RuleFor(course => course.CourseName)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve ter ente {MinLength} e {MaxLength}.");
            RuleFor(course => course.CourseLevel).SetValidator(new CourseLevelValidation());
        }
    }
}