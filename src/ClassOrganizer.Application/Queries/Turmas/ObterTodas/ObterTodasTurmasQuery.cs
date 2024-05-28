using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;

namespace ClassOrganizer.Application.Queries.Turmas.ObterTodas
{
    public record ObterTodasTurmasQuery : Query<IEnumerable<TurmaDTO>>
    {
    }
}
