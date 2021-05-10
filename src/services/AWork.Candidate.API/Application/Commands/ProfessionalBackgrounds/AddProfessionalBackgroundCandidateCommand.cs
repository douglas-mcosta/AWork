using AWork.Core.Messages;
using FluentValidation;
using System;

namespace AWork.Candidates.API.Application.Commands.ProfessionalBackgrounds
{
    public class AddProfessionalBackgroundCandidateCommand : Command
    {
        public Guid CandidateId { get; private set; }
        public Guid JobTitleLevelId { get; private set; }
        public Guid WorkingAreaId { get; private set; }
        public string JobTitleName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool CurrentJob { get; private set; }
        public string DescriptionJob { get; private set; }
        public string Company { get; private set; }

        public AddProfessionalBackgroundCandidateCommand(Guid candidateId, Guid jobTitleLevelId, Guid workingAreaId, string jobTitleName, DateTime startDate, DateTime? endDate, bool currentJob, string descriptionJob, string company)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            JobTitleLevelId = jobTitleLevelId;
            WorkingAreaId = workingAreaId;
            JobTitleName = jobTitleName;
            StartDate = startDate;
            EndDate = endDate;
            CurrentJob = currentJob;
            DescriptionJob = descriptionJob;
            Company = company;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProfessionalBackgroundCandidateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddProfessionalBackgroundCandidateCommandValidation : AbstractValidator<AddProfessionalBackgroundCandidateCommand>
    {
        public AddProfessionalBackgroundCandidateCommandValidation()
        {
            RuleFor(p => p.CandidateId)
                .NotEqual(Guid.Empty);

            RuleFor(p => p.JobTitleLevelId)
                .NotEqual(Guid.Empty);

            RuleFor(p => p.WorkingAreaId)
                .NotEqual(Guid.Empty);

            RuleFor(p => p.JobTitleName)
                .NotEmpty().WithMessage("Informe o cargo em que atuava.")
                .Length(2, 60).WithMessage("O Nome do Cargo deve conter entre {MixLength} e {MaxLength} caracteres");

            RuleFor(p => p.DescriptionJob)
               .NotEmpty().WithMessage("Descreva o suas atividades")
               .Length(2, 500).WithMessage("A descrição deve conter entre {MixLength} e {MaxLength} caracteres");

            RuleFor(p => p.Company)
                .NotEmpty().WithMessage("Informe o nome da empresa")
                .Length(2, 100).WithMessage("O Nome do Empresa deve conter entre {MixLength} e {MaxLength} caracteres");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("Informe a data de admissão.");

            When(p => !p.CurrentJob, () =>
            {
                RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("Informe a data de recisão.");
            });

        }
    }
}
