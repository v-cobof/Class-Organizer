using ClassOrganizer.Domain.Core;

namespace ClassOrganizer.Domain.Entidades
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        public Aluno(string nome, string usuario, string senha)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
        }
    }
}
