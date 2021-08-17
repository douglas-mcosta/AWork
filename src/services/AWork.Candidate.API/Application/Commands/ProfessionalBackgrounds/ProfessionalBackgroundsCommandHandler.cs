using System.Threading;
using System.Threading.Tasks;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Candidatos.Domain.Models;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;

namespace AWork.Candidatos.API.Application.Commands.ProfessionalBackgrounds
{
    public class ProfessionalBackgroundsCommandHandler : CommandHandler,
        IRequestHandler<AddProfessionalBackgroundCandidateCommand, ValidationResult>
    {

        private readonly ICandidateRepository _candidateRepository;

        public ProfessionalBackgroundsCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<ValidationResult> Handle(AddProfessionalBackgroundCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.GetCandidateWithProfessionalBackground(message.CandidateId);

            if(candidate == null)
            {
                AddError("Candidato Invalido");
                return ValidationResult;
            }
            
            var professionalBackground = new ProfessionalBackground(message.CandidateId,message.JobTitleLevelId, message.WorkingAreaId,message.JobTitleName,message.StartDate,message.EndDate,message.CurrentJob,message.DescriptionJob,message.Company);
            candidate.AddProfessionalBackground(professionalBackground);
             _candidateRepository.Update(candidate);

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
    }
}
