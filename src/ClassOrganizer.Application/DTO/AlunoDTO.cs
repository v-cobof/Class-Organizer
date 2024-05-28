using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.DTO
{
    public record AlunoDTO
    {
        public int Id {  get; set; }
        public string Nome {  get; set; }
        public string Usuario {  get; set; }
        public string Senha {  get; set; }

        public AlunoDTO(Aluno aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            Usuario = aluno.Usuario;
            Senha = aluno.Senha;
        }
    }
}
