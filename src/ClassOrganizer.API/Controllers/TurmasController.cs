using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;

namespace ClassOrganizer.API.Controllers
{
    public class TurmasController : AbstractController
    {
        public TurmasController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
        }
    }
}
