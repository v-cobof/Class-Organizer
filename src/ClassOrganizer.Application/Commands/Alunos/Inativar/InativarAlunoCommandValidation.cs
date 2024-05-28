using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Inativar
{
    public class InativarAlunoCommandValidation : AbstractValidator<InativarAlunoCommand>
    {
        public InativarAlunoCommandValidation()
        {
            RuleFor(t => t.Id).RegraId();
        }
    }
}
