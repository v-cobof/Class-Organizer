using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;

namespace ClassOrganizer.Application.Queries.AlunosTurmas.ObterTodosAlunosNaTurma
{
    public record ObterTodosAlunosNaTurmaQuery : Query<IEnumerable<AlunoDTO>>
    {
        public int TurmaId { get; set; }
    }
}
