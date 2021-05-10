using AWork.Candidates.API.Extensions;
using AWork.Candidates.Domain.Interfaces.Repository;
using AWork.Candidates.Domain.Models;
using AWork.Core.Communication.Mediator;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Commands.JobTitleInteresteds
{
    public class JobTitleInterestedCandidateCommandHandler : CommandHandler,
        IRequestHandler<AddJobTitleInterestedCandidateCommand, ValidationResult>,
        IRequestHandler<ChangeFavoriteJobTitleInterestedCommand, ValidationResult>,
        IRequestHandler<DeleteJobTitleInterestedCandidateCommand, ValidationResult>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly AppSettings _settings;

        public JobTitleInterestedCandidateCommandHandler(ICandidateRepository candidateRepository,
                                            IOptions<AppSettings> settings)
        {
            _candidateRepository = candidateRepository;
            _settings = settings.Value;
        }

        public async Task<ValidationResult> Handle(AddJobTitleInterestedCandidateCommand messsage, CancellationToken cancellationToken)
        {
            if (!messsage.IsValid()) return messsage.ValidationResult;
            var candidate = await GetCandidate(messsage.CandidateId);
            if (candidate == null)
            {
                AddError(messsage.MessageType, "Candidato invalido.");
                return ValidationResult;
            }
            if (candidate.JobTitleInteresteds.Count > _settings.AppConfig.MaximumNumberJobTitleInterestedByCandidate)
            {
                AddError(messsage.MessageType, "Número maximo de cargos de interesse cadastrado.");
                return ValidationResult;
            }
            var jobTitle = await _candidateRepository.FindJobTitleById(messsage.JobTitleId);
            if(jobTitle == null)
            {
                AddError("O Cargo de interesse é inválido.");
                return ValidationResult;
            }

            var jobTitleInterested = new JobTitleInterested(messsage.CandidateId, messsage.JobTitleId, messsage.IsDefault);
            if (candidate.HasThisJobTitleInterestedRegistered(jobTitleInterested))
            {
                AddError(messsage.MessageType, "Esse cargo de interesse já está cadastrado.");
                return ValidationResult;
            }

            candidate.AddJobTitleInterested(jobTitleInterested);

            _candidateRepository.UpdateJobTitleInterested(candidate.JobTitleInteresteds.ToList());
            await _candidateRepository.AddJobTitleInterested(jobTitleInterested);

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ChangeFavoriteJobTitleInterestedCommand messsage, CancellationToken cancellationToken)
        {
            if (!messsage.IsValid()) return messsage.ValidationResult;
            var candidate = await GetCandidate(messsage.CandidateId);
            if (candidate == null)
            {
                AddError(messsage.MessageType, "Candidato invalido.");
                return ValidationResult;
            }

            var jobTitleInterested = await _candidateRepository.FindJobTitleInterestedsById(messsage.Id);
            if (jobTitleInterested.CandidateId != messsage.CandidateId)
            {
                AddError("O Cargo de Interesse não pertence ao usuário.");
                return ValidationResult;
            }

            candidate.ChangeFavoriteJobTitleInterested(jobTitleInterested);

            _candidateRepository.UpdateJobTitleInterested(candidate.JobTitleInteresteds.ToList());

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteJobTitleInterestedCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.GetCandidateWithJobTitleInteresteds(message.CandidateId);
            if (candidate == null)
            {
                AddError(message.MessageType, "Candidato invalido.");
                return ValidationResult;
            }

            var jobTitleInterested = await _candidateRepository.FindJobTitleInterestedsById(message.Id);
            if (jobTitleInterested.CandidateId != message.CandidateId)
            {
                AddError("O Cargo de Interesse não pertence ao usuário.");
                return ValidationResult;
            }


            if (jobTitleInterested.IsDefault)
            {
                AddError("Não é permitido apagar o Cargo de Interesse padrão.");
                return ValidationResult;
            }

            candidate.DeleteJobTitleInterested(jobTitleInterested);
             _candidateRepository.DeleteJobTitleInterested(jobTitleInterested);

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        private async Task<Candidate> GetCandidate(Guid candidateId)
        {
            var candidate = await _candidateRepository.GetCandidateWithJobTitleInteresteds(candidateId);
            return candidate;
        }
    }
}
