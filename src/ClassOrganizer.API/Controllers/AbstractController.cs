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
            var metodo = HttpContext.Request.Method;

            if (OperacaoEhValida())
            {
                return metodo switch
                {
                    "GET" => Ok(result),
                    "POST" => Created(),
                    "PUT" => NoContent(),
                    "DELETE" => NoContent(),
                    _ => Ok(result),
                };
            }

            return metodo switch
            {
                "GET" => NotFound(),
                "POST" => BadRequestComMensagens(),
                "PUT" => HandleErroPutDelete(),
                "DELETE" => HandleErroPutDelete(),
                _ => Ok(result),
            };           
        }

        private ActionResult HandleErroPutDelete()
        {
            var erros = _notificationHandler.GetErrors().ToArray();

            if (erros.Any(t => t.ToLower().Contains("não foi encontrad")))
            {
                return NotFound();
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", erros }
            }));
        }

        private BadRequestObjectResult BadRequestComMensagens()
        {
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
