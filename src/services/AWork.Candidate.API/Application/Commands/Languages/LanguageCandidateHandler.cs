using AWork.Candidates.Domain.Interfaces.Repository;
using AWork.Candidates.Domain.Models;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Commands.Languages
{
    public class LanguageCandidateHandler : CommandHandler,
        IRequestHandler<AddLanguageCandidateCommand, ValidationResult>,
        IRequestHandler<UpdateLanguageFluencyLevelCommand, ValidationResult>,
        IRequestHandler<DeleteLanguageCandidateCommand, ValidationResult>
    {
        private readonly ICandidateRepository _candidateRepository;

        public LanguageCandidateHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<ValidationResult> Handle(AddLanguageCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var candidate = await _candidateRepository.GetCandidateLanguages(message.CandidateId);
            if (candidate == null)
            {
                AddError("Candidato inválido");
                return ValidationResult;
            }
            var language = await _candidateRepository.FindLanguageById(message.LanguageId);
            if (language == null)
            {
                AddError("Idioma inválido.");
                return ValidationResult;
            }

            if (HasLanguage(message.LanguageId,candidate.Id))
            {
                AddError("Idioma já cadastrado.");
                return ValidationResult;
            }
            var languageCandidate = new LanguageCandidate(message.Id,message.CandidateId, message.LanguageId,message.FluencyLevel);
            candidate.AddLanguageCandidate(languageCandidate);

            await _candidateRepository.AddLanguageCandidate(languageCandidate);
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async  Task<ValidationResult> Handle(UpdateLanguageFluencyLevelCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.GetCandidateLanguages(message.CandidateId);
            if(candidate == null)
            {
                AddError("Candidato inválido.");
                return ValidationResult;
            }

            var languageCandidate = await _candidateRepository.FindLanguagesCandidateById(message.LanguageCandidateId);
            if(languageCandidate == null)
            {
                AddError("Idioma não pertence ao usuário.");
                return ValidationResult;
            }

            candidate.UpdateFluencyLevel(languageCandidate, message.FluencyLevel);

            _candidateRepository.Update(candidate);

            return await  SaveChanges(_candidateRepository.UnitOfWork);
           
        }

        public async Task<ValidationResult> Handle(DeleteLanguageCandidateCommand messege, CancellationToken cancellationToken)
        {
            if (!messege.IsValid()) return messege.ValidationResult;

            var candidate = await _candidateRepository.GetCandidateLanguages(messege.CandidateId);

            if(candidate == null)
            {
                AddError("Candidato inválido");
                return ValidationResult;
            }

            var languageCandidate = candidate.Languages.FirstOrDefault(l => l.Id == messege.Id);
           
            if(languageCandidate == null)
            {
                AddError("Idioma não pertence ao usuário.");
                return ValidationResult;
            }
            _candidateRepository.DeleteLanguageCandidate(languageCandidate);
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        private bool HasLanguage(Guid languageId, Guid candidateId) {
            var candidateHasThisLanguage = _candidateRepository.SearchLanguageCandidate(l => l.LanguageId== languageId && l.CandidateId == candidateId).Result;
            return candidateHasThisLanguage.Count > 0;
        }
    }
}
