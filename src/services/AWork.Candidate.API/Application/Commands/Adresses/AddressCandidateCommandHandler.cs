using System.Threading;
using System.Threading.Tasks;
using AWork.Candidatos.Domain.Interfaces.Repository;
using AWork.Candidatos.Domain.Models;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;

namespace AWork.Candidatos.API.Application.Commands.Adresses
{
    public class AddressCandidateCommandHandler : CommandHandler,
        IRequestHandler<AddAddressCandidateCommand, ValidationResult>,
        IRequestHandler<UpdateAddressCandidateCommand, ValidationResult>
    {
        private readonly ICandidateRepository _candidateRepository;

        public AddressCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<ValidationResult> Handle(AddAddressCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.FindById(message.CandidateId);
            if (candidate == null)
            {
                AddError("Informe um candidato valido.");
                return ValidationResult;
            }

            var address = new Address(message.Id, message.CountryId,message.ZipCode,message.District,message.Street,message.Number,message.Complement,message.State,message.City);
            await _candidateRepository.AddAddress(address);
            candidate.AddAddress(address);
            _candidateRepository.Update(candidate);

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateAddressCandidateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var candidate = await _candidateRepository.FindById(message.CandidateId);
            if (candidate == null)
            {
                AddError("Informe um candidato valido.");
                return ValidationResult;
            }

            var address = new Address(message.Id, message.CountryId, message.ZipCode, message.District, message.Street, message.Number, message.Complement, message.State, message.City);
            address.AssociateCandidateAddress(message.CandidateId); 
            _candidateRepository.UpdateAddress(address);

            return await SaveChanges(_candidateRepository.UnitOfWork);
        }
    }
}
