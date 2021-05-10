using AWork.Core.Messages;
using System.Threading.Tasks;
using MediatR;
using FluentValidation.Results;

namespace AWork.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
