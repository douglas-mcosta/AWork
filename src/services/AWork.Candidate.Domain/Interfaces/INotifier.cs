using AWork.Candidates.Domain.Notifications;
using System.Collections.Generic;

namespace AWork.Candidates.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotificacoes();
        void Handler(Notification notification);
    }
}
