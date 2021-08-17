using System;
using AWork.Core.Messages;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.Adresses
{
    public class UpdateAddressCandidateCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid CandidateId { get; private set; }
        public Guid CountryId { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public UpdateAddressCandidateCommand(Guid id, Guid candidateId, Guid countryId, string zipCode, string district, string street, string number, string complement, string state, string city)
        {
            Id = id;
            AggregateId = candidateId;
            CandidateId = candidateId;
            CountryId = countryId;
            ZipCode = zipCode;
            District = district;
            Street = street;
            Number = number;
            Complement = complement;
            State = state;
            City = city;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAddressCandidateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateAddressCandidateCommandValidation : AbstractValidator<UpdateAddressCandidateCommand>
    {

        public UpdateAddressCandidateCommandValidation()
        {
            RuleFor(a => a.CandidateId)
                .NotEmpty().WithMessage("Candidato inválido.")
                .NotEqual(Guid.Empty).WithMessage("Candidato inválido.");

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
