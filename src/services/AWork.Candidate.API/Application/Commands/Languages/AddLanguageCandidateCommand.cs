using System;
using AWork.Core.DomainObjects.Enums;
using AWork.Core.Messages;
using AWork.Core.Utils;
using FluentValidation;

namespace AWork.Candidatos.API.Application.Commands.Languages
{
    public class AddLanguageCandidateCommand : Command
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid LanguageId { get; set; }
        public virtual FluencyLevel FluencyLevel { get; set; }

        public AddLanguageCandidateCommand(Guid id, Guid candidateId, Guid languageId, FluencyLevel fluencyLevel)
        {
            AggregateId = candidateId;
            Id = id;
            CandidateId = candidateId;
            LanguageId = languageId;
            FluencyLevel = fluencyLevel;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddLanguageCandidateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddLanguageCandidateCommandValidation : AbstractValidator<AddLanguageCandidateCommand>
    {

        public AddLanguageCandidateCommandValidation()
        {
            RuleFor(lang => lang.LanguageId)
           .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(lang => lang.FluencyLevel)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Must(FluencyLevelValidate).WithMessage("O Nivel de Fluencia é inválido");

            RuleFor(lang => lang.CandidateId)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }

        private bool FluencyLevelValidate(FluencyLevel fluencyLevel)
        {
            return fluencyLevel.Validate();
        }
    }
}
