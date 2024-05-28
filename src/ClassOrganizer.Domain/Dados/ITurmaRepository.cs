using ClassOrganizer.Domain.Core.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Domain.Dados
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma> ObterPorNomeTurma(string nomeTurma);
        Task<bool> AssociarAlunoATurma(int alunoId, int turmaId);
        Task<bool> InativarAssociacaoAlunoATurma(int alunoId, int turmaId);
    }
}
