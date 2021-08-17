using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AWork.Candidatos.API.Application.Events.Phones
{
    public class PhoneCandidateEventHandler :
        INotificationHandler<AddPhoneCandidateEvent>
    {
        public Task Handle(AddPhoneCandidateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
