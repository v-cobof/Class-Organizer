using ClassOrganizer.Application;
using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassOrganizer.API.Controllers
{
    public class AbstractController : ControllerBase
    {
        protected readonly DomainNotificationHandler _notificationHandler;
        protected readonly IMediatorHandler _mediator;

        public AbstractController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
        {
            _notificationHandler = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoEhValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _notificationHandler.GetErrors().ToArray() }
            }));
        }

        protected async Task<ActionResult> EnviarComando(Command command)
        {
            var result = _mediator.SendCommand(command);

            return CustomResponse(await result);
        }

        protected async Task<ActionResult> EnviarQuery<T>(Query<T> query)
        {
            var result = _mediator.SendQuery(query);

            return CustomResponse(await result);
        }

        protected bool OperacaoEhValida()
        {
            return !_notificationHandler.HasNotification();
        }

        protected void LimparErros()
        {
            _notificationHandler.ClearNotifications();
        }
    }
}
