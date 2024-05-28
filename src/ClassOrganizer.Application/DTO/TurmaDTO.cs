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
    }
}
