using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.DTO
{
    public record AlunoMinDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }

        public AlunoMinDTO(Aluno aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            Usuario = aluno.Usuario;
        }

        public AlunoMinDTO() { }
    }
}
