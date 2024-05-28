using ClassOrganizer.Domain.Core.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Domain.Dados
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterAlunoPorIdETurma(int id, int turmaId);
        Task<IEnumerable<Aluno>> ObterTodosAlunoNaTurma(int turmaId);
    }
}
