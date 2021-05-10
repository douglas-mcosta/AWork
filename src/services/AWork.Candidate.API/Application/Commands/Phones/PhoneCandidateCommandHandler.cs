using AWork.Candidates.API.Application.Events.Phones;
using AWork.Candidates.API.Extensions;
using AWork.Candidates.Domain.Interfaces.Repository;
using AWork.Candidates.Domain.Models;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Commands.Phones
{
    public class PhoneCandidateCommandHandler : CommandHandler,
        IRequestHandler<AddPhoneCandidateCommand, ValidationResult>,
        IRequestHandler<UpdatePhoneCandidateCommand, ValidationResult>,
        IRequestHandler<ChangeFavoritePhoneCandidateCommand, ValidationResult>,
        IRequestHandler<DeletePhoneCandidateCommand, ValidationResult>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly  AppSettings _settings;

        public PhoneCandidateCommandHandler(ICandidateRepository candidateRepository,                                       
                                            IOptions<AppSettings> settings)
        {
            _candidateRepository = candidateRepository;
            _settings = settings.Value;
        }

        public async Task<ValidationResult> Handle(AddPhoneCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await GetCandidateById(message.CandidateId);

            if (candidate == null)
            {
                AddError("Candidato invalido. Verique o Id.");
                return ValidationResult;
            }

            if (HasMaximumNumberPhonesByCandidate(candidate))
            {
                AddError("Numero máximo de telefones cadastrados");
                return ValidationResult;
            }
            var phone = new Phone(message.PhoneId, message.CandidateId, message.PhoneNumber, message.IsDefault, message.PhoneType);

            if (candidate.HasThisPhoneNumberRegistered(phone))
            {
                AddError("Você ja cadastrou esse número.");
                return ValidationResult;
            }
            if (await HasOtherCandidateThisPhone(phone))
            {
                AddError("Já existe uma pessoa com esse telefone cadastrado");
                return ValidationResult;
            }

            candidate.AddPhone(phone);
            
            _candidateRepository.UpdatePhones(candidate.Phones.ToList());
            await _candidateRepository.AddPhone(phone);
            candidate.AddEvent(new AddPhoneCandidateEvent(phone.Id, phone.CandidateId, phone.PhoneNumber, phone.Default, phone.PhoneType));
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdatePhoneCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var candidate = await GetCandidateById(message.CandidateId);
            if (candidate == null)
            {
               AddError(message.MessageType, "Candidato inválido.");
                return ValidationResult;
            }
            var phone = await GetPhoneById(message.PhoneId);
            if (phone == null)
            {
                AddError(message.MessageType, "Telefone não encontrado");
                return ValidationResult;
            }

            phone = new Phone(message.PhoneId, message.CandidateId, message.PhoneNumber, message.IsDefault, message.PhoneType);
            
            if (candidate.NotCanChangePhoneToNotDefault(phone))
            {
                AddError(message.MessageType, "O Candidato deve ter ao menos um telefone padrão.");
                return ValidationResult;
            }
            if (await HasOtherCandidateThisPhone(phone))
            {
                AddError(message.MessageType, "Já existe uma pessoa com esse telefone cadastrado");
                return ValidationResult;
            }
            
            candidate.UpdatePhone(phone);
            _candidateRepository.UpdatePhones(candidate.Phones.ToList());
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(ChangeFavoritePhoneCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var candidate = await GetCandidateById(message.CandidateId);

            if (candidate == null)
            {
                AddError(message.MessageType, "Candidato invalido.");
                return ValidationResult;
            }
            var phone =  await GetPhoneById(message.PhoneId);
            if (phone == null)
            {
                AddError(message.MessageType, "Telefone não encontrado");
                return ValidationResult;
            }
            phone.SetDefault();
            candidate.UpdatePhone(phone);
            _candidateRepository.UpdatePhones(candidate.Phones.ToList());
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(DeletePhoneCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await GetCandidateById(request.CandidateId);

            if (candidate == null)
            {
                AddError(request.MessageType, "Candidato inválido.");
                return ValidationResult;
            }
            var phone = await GetPhoneById(request.PhoneId);
            if (phone == null)
            {
                AddError(request.MessageType, "Telefone não encontrado.");
                return ValidationResult;
            }
            if(phone.CandidateId != candidate.Id) 
            {
                AddError(request.MessageType, "Não é permitido deletar um registro de outro usuário.");
                return ValidationResult;
            }
            if (phone.IsDefault())
            {
                AddError(request.MessageType, "Não é permitido remover o telefone padrão.");
                return ValidationResult;
            }
            candidate.DeletePhone(phone);
            _candidateRepository.DeletePhone(phone);
            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        private bool HasMaximumNumberPhonesByCandidate(Candidate candidate)
        {
            int MAXIMUM_NUMBER_PHONES_BY_CANDIDATE = _settings.AppConfig.MaximumNumberPhoneByCandidate;
            return candidate.PhoneCount() >= MAXIMUM_NUMBER_PHONES_BY_CANDIDATE;
        }
        private async Task<Candidate> GetCandidateById(Guid candidateId)
        {
            var candidate = await _candidateRepository.GetCandidateWithPhones(candidateId);
            return candidate;
        }
        private async Task<bool> HasOtherCandidateThisPhone(Phone phone)
        {
            var hasCandidateThisPhone = await _candidateRepository.HasOtherCandidateThisPhone(phone);
            return hasCandidateThisPhone;
        }
        private async Task<Phone> GetPhoneById(Guid phoneId)
        {
            var phone = await _candidateRepository.FindPhoneById(phoneId);
            return phone;
        }
    }
}
