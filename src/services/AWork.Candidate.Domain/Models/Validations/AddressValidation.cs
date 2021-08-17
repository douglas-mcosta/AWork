using FluentValidation;

namespace AWork.Candidatos.Domain.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(p => p.City)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.CountryId)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 70).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.Number)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(1, 15).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.Street)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.District)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.Complement)
              .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
               .Length(2, 200).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength}.");

            RuleFor(p => p.ZipCode)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(8).WithMessage("O campo {PropertyName} deve conter {MaxLength} caracteres.");
        }
    }
}
