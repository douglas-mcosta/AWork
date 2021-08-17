using System;
using System.Threading;
using System.Threading.Tasks;
using AWork.Candidatos.API.Application.Commands.CandidateData;
using AWork.Core.Communication.Mediator;
using AWork.Core.Messages.Integration;
using AWork.MessageBus;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AWork.Candidatos.API.Services
{
    public class RegisterCandidateIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegisterCandidateIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(async request => await RegisterCandidate(request));
            _bus.AdvancedBus.Connected += OnConnect;
        }
        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }
        private async Task<ResponseMessage> RegisterCandidate(RegisteredUserIntegrationEvent message)
        {
            var candidateCommand = new RegisterCandidateCommand(message.Id, message.CPF, message.FirstName, message.LastName, message.Email, message.BirthDate, message.Gender);
            ValidationResult success = null;
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                success = await mediator.SendCommand(candidateCommand);
            }

            return new ResponseMessage(success);
        }
    }
}
