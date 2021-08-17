using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AWork.Candidatos.API.Application.Events
{
    public class CandidateEventHandler :
        INotificationHandler<RegisteredCandidateEvent>,
        INotificationHandler<ChangeCandidatePersonDataEvent>,
        INotificationHandler<UpdatedGoalCandidateEvent>
    {
        public Task Handle(RegisteredCandidateEvent notification, CancellationToken cancellationToken)
        {
            //TODO: Enviar E-mail de confirmação
            return Task.CompletedTask;
        }
        public Task Handle(ChangeCandidatePersonDataEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(UpdatedGoalCandidateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

      
    }
}
