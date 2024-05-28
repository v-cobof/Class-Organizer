using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;

namespace ClassOrganizer.Application.Queries.Turmas.ObterPorId
{
    public record ObterTurmaPorIdQuery : Query<TurmaDTO>
    {
        public int Id { get; set; }
    }
}
