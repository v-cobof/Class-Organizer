using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Domain.Core.Comunicacao
{
    public record Command : IRequest<CommandResult>
    {
    }
}
