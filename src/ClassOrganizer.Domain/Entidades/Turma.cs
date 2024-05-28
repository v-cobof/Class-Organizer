using ClassOrganizer.Domain.Core;

namespace ClassOrganizer.Domain.Entidades
{
    public class Turma : Entidade
    {
        public int CursoId { get; private set; }
        public string NomeTurma { get; private set; }
        public int Ano { get; private set; }

        public Turma(int cursoId, string nomeTurma, int ano)
        {
            CursoId = cursoId;
            NomeTurma = nomeTurma;
            Ano = ano;
        }

        public void AtualizarCursoId(int cursoId)
        {
            CursoId = cursoId;
        }

        public void AtualizarNomeTurma(string nomeTurma)
        {
            NomeTurma = nomeTurma;
        }

        public void AtualizarAno(int ano)
        {
            Ano = ano;
        }
    }
}
