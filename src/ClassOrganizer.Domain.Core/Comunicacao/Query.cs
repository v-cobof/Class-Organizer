using MediatR;

namespace ClassOrganizer.Domain.Core.Comunicacao
{
    public record Query<T> : IRequest<T>
    {
    }
}
