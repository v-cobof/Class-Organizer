using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands
{
    public abstract class BaseCommandHandler<TReq> : IRequestHandler<TReq, CommandResult> where TReq : Command
    {
        protected readonly IMediatorHandler _mediator;

        public BaseCommandHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public abstract Task<CommandResult> Handle(TReq request, CancellationToken cancellationToken);

        protected async Task Notify(string message)
        {
            var notification = new DomainNotification(typeof(TReq).Name, message);

            await _mediator.PublishNotification(notification);
        }
    }
}
