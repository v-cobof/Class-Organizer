using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries
{
    public abstract class BaseQueryHandler<TReq, TRes> : IRequestHandler<TReq, TRes> where TReq : Query<TRes>
    {
        protected readonly IMediatorHandler _mediator;

        public BaseQueryHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public abstract Task<TRes> Handle(TReq request, CancellationToken cancellationToken);

        protected async Task Notificar(string message)
        {
            var notification = new DomainNotification(typeof(TReq).Name, message);

            await _mediator.PublishNotification(notification);
        }
    }


}
