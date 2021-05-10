using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AWork.Candidates.API.Application.Events.Phones
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
