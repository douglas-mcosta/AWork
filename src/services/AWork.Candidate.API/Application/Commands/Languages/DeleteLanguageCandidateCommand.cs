using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.Languages
{
    public class DeleteLanguageCandidateCommand : Command
    {
        public DeleteLanguageCandidateCommand(Guid id, Guid candidateId)
        {
            AggregateId = candidateId;
            Id = id;
            CandidateId = candidateId;
        }

        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteLanguageCandidateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

   public class DeleteLanguageCandidateCommandValidation : AbstractValidator<DeleteLanguageCandidateCommand>
    {
        public DeleteLanguageCandidateCommandValidation()
        {
            RuleFor(p => p.CandidateId)
                .NotEqual(Guid.Empty).WithMessage("Candidato inválido");

            RuleFor(p => p.Id)
               .NotEqual(Guid.Empty).WithMessage("Idioma inválido");
        }
    }
}
