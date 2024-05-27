using ClassOrganizer.Domain.Core.Comunicacao;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Pipeline
{
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : Command, IRequest<TRes> where TRes : CommandResult
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;
        private readonly IMediatorHandler _bus;

        public ValidationBehaviour(IEnumerable<IValidator<TReq>> validators, IMediatorHandler bus)
        {
            _validators = validators;
            _bus = bus;
        }

        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TReq>(request);

            var notifications = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => new DomainNotification(request.GetType().Name, x.ErrorMessage))
                .ToList();

            if (notifications.Any())
            {
                await _bus.PublishNotificationsBatch(notifications);

                return await Task.FromResult((TRes)CommandResult.Falha());
            }

            return await next();
        }
    }
}
