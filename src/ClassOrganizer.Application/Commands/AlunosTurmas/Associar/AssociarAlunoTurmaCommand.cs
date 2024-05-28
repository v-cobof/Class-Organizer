using ClassOrganizer.Domain.Core.Comunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.AlunosTurmas.Associar
{
    public record AssociarAlunoTurmaCommand : Command
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
    }
}
