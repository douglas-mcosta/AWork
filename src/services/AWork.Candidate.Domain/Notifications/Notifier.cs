using AWork.Candidates.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AWork.Candidates.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notification;

        public Notifier()
        {
            _notification = new List<Notification>();
        }
        public List<Notification> GetNotificacoes()
        {
            return _notification;
        }

        public void Handler(Notification notification)
        {
            _notification.Add(notification);
        }

        public bool HasNotification()
        {
            return _notification.Any();
        }
    }
}
