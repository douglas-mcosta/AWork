using FluentValidation;

namespace AWork.Candidatos.Domain.Models.Validations
{
    public class CountryValidation : AbstractValidator<Country>
    {
        public CountryValidation()
        {
            RuleFor(country => country.Name)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength}.");

            RuleFor(country => country.Nationality)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Length(5, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength}.");
        }
    }
}