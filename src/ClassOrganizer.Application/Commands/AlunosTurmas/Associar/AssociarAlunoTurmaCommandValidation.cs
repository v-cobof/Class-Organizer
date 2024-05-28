using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.AlunosTurmas.Associar
{
    public class AssociarAlunoTurmaCommandValidation : AbstractValidator<AssociarAlunoTurmaCommand>
    {
        public AssociarAlunoTurmaCommandValidation()
        {
            RuleFor(t => t.AlunoId)
                .GreaterThan(0).WithMessage("O identificador do aluno não foi enviado.");

            RuleFor(t => t.TurmaId)
                .GreaterThan(0).WithMessage("O identificador da turma não foi enviado.");
        }
    }
}
