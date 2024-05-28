using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Infrastructure.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task PublishNotificationsBatch<T>(IEnumerable<T> notifications) where T : DomainNotification
        {
            var tasks = notifications.Select(t => PublishNotification(t)).ToList();

            await Task.WhenAll(tasks);
        }

        public async Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task<T> SendQuery<T>(Query<T> query)
        {
            return await _mediator.Send(query);
        }
    }
}
