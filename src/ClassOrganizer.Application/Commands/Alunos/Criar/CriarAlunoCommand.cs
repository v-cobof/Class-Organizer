using ClassOrganizer.Domain.Core.Comunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.CriarAluno
{
    public record CriarAlunoCommand : Command
    {
        public string Nome {  get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
