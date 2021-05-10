using AWork.Candidates.API.Application.Events;
using AWork.Candidates.Domain.Interfaces.Repository;
using AWork.Candidates.Domain.Models;
using AWork.Core.Communication.Mediator;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Commands.CandidateData
{
    public class CandidateCommandHandler : CommandHandler,
        IRequestHandler<RegisterCandidateCommand, ValidationResult>,
        IRequestHandler<ChangeCandidatePersonDataCommand, ValidationResult>,
        IRequestHandler<UpdateGoalCandidateCommand, ValidationResult>,
        IRequestHandler<UpdateSummaryCandidateCommand, ValidationResult>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<ValidationResult> Handle(RegisterCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = new Candidate(message.Id, message.FirstName, message.LastName, message.BirthDate, message.Gender, message.CPF);
            var hasCandidateThisCpf = _candidateRepository.HasCandidateWithThisCPF(message.CPF);

            if (hasCandidateThisCpf)
            {
                AddError("Já existe um candidato com esse CPF cadastrado");
                return ValidationResult;
            }

            await _candidateRepository.Add(candidate);
            candidate.AddEvent(new RegisteredCandidateEvent(message.Id,message.CPF, message.FirstName, message.LastName, message.Email, message.BirthDate, message.Gender));

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(UpdateGoalCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.GetCandidateProfileCompleted(message.CandidateId);

            if (candidate == null)
            {
                AddError(message.MessageType, "Id Inválido.");
                return ValidationResult;
            }

            candidate.UpdateGoal(message.Goal);
            _candidateRepository.Update(candidate);
            candidate.AddEvent(new UpdatedGoalCandidateEvent(candidate.Id, candidate.Goal));
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ChangeCandidatePersonDataCommand messsage, CancellationToken cancellationToken)
        {
            if (!messsage.IsValid()) return messsage.ValidationResult;
            var candidate = await _candidateRepository.GetCandidateProfileCompleted(messsage.CandidateId);
            if (candidate == null)
            {
                AddError(messsage.MessageType, "Id Inválido.");
                return ValidationResult;
            }
            candidate.ChangeCandidatPersonData(
                                                messsage.FirstName,
                                                messsage.LastName,
                                                messsage.BirthDate,
                                                messsage.Gender,
                                                messsage.MaritalStatusId,
                                                messsage.NationalityId,
                                                messsage.SpecialNeedsId,
                                                messsage.ReligionId);
            _candidateRepository.Update(candidate);
            candidate.AddEvent(new ChangeCandidatePersonDataEvent(
                                                messsage.CandidateId,
                                                messsage.FirstName,
                                                messsage.LastName,
                                                messsage.BirthDate,
                                                messsage.Gender,
                                                messsage.MaritalStatusId,
                                                messsage.NationalityId,
                                                messsage.SpecialNeedsId,
                                                messsage.ReligionId));

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateSummaryCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult; ;

            var candidate = await _candidateRepository.GetCandidateProfileCompleted(message.CandidateId);
            if (candidate == null)
            {
                AddError(message.MessageType, "Id Inválido.");
                return ValidationResult;
            }
            candidate.UpdateSummary(message.Summary);
            _candidateRepository.Update(candidate);
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
             
    }
}
