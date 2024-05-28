using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.DTO
{
    public record TurmaDTO
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string NomeTurma { get; set; }
        public int Ano { get; set; }

        public TurmaDTO(Turma turma)
        {
            Id = turma.Id;
            CursoId = turma.CursoId;
            NomeTurma = turma.NomeTurma;
            Ano = turma.Ano;
        }
    }
}
