using ClassOrganizer.Domain.Core.Comunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Inativar
{
    public record InativarAlunoCommand : Command
    {
        public int Id { get; set; }
    }
}
