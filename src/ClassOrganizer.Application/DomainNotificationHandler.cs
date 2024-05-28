using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public IEnumerable<string> GetErrors()
        {
            return _notifications.Select(t => t.Value);
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }
    }
}
