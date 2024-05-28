using ClassOrganizer.Domain.Core.Comunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Turmas.Editar
{
    public record EditarTurmaCommand : Command
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string NomeTurma { get; set; }
        public int Ano { get; set; }
    }
}
