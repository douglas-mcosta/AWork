using AWork.Core.DomainObjects.Enums;
using FluentValidation;

namespace AWork.Candidates.Domain.Models.Validations
{
    public class PhoneValidation : AbstractValidator<Phone>
    {
        public PhoneValidation()
        {
            When(p => p.PhoneType == PhoneType.CellPhone, () =>
            {
                RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .Length(11).WithMessage("O campo Celular deve conter {MaxLength} caracteres.");
            });

            When(p => p.PhoneType == PhoneType.HomePhone, () =>
            {
                RuleFor(p => p.PhoneNumber)
                  .NotEmpty()
                  .Length(10).WithMessage("O campo Telefone Residencial deve conter {MaxLength} caracteres.");
            });
        }

    }
}
