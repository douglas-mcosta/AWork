using System;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using AWork.Core.Utils;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.Languages
{
    public class UpdateLanguageFluencyLevelCommand : Command
    {
        public UpdateLanguageFluencyLevelCommand(Guid languageCandidateId, Guid candidateId, FluencyLevel fluencyLevel)
        {
            AggregateId = candidateId;
            LanguageCandidateId = languageCandidateId;
            CandidateId = candidateId;
            FluencyLevel = fluencyLevel;
        }

        public Guid LanguageCandidateId { get; private set; }
        public Guid CandidateId { get; private set; }
        public FluencyLevel FluencyLevel { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateLanguageFluencyLevelValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class UpdateLanguageFluencyLevelValidation : AbstractValidator<UpdateLanguageFluencyLevelCommand>
    {
        public UpdateLanguageFluencyLevelValidation()
        {
            RuleFor(l => l.LanguageCandidateId)
                .NotEmpty().WithMessage("LanguageCandidateId é obrigatório.")
                .NotEqual(Guid.Empty).WithMessage("Registro de idioma inválido.");

            RuleFor(l => l.CandidateId)
               .NotEmpty().WithMessage("CandidateId é obrigatório.")
               .NotEqual(Guid.Empty).WithMessage("Candidato inválido");

            RuleFor(l => l.FluencyLevel)
             .Must(FluencyLevelValidate).WithMessage("O Nivel de Fluencia é inválido");
        }

        private bool FluencyLevelValidate(FluencyLevel fluencyLevel)
        {
            return fluencyLevel.Validate();
        }
    }
}
