using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Domain.Core.Comunicacao
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<T>(T command) where T : Command;
        Task<T> SendQuery<T>(Query<T> query);
        Task PublishNotification<T>(T notification) where T : DomainNotification;
        Task PublishNotificationsBatch<T>(IEnumerable<T> notifications) where T : DomainNotification;
    }
}
