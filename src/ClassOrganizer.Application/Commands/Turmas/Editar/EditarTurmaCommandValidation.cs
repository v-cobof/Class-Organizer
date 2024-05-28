using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Turmas.Editar
{
    public class EditarTurmaCommandValidation : AbstractValidator<EditarTurmaCommand>
    {
        public EditarTurmaCommandValidation()
        {
            RuleFor(p => p.CursoId)
                .RegraCurso();

            RuleFor(p => p.NomeTurma)
                .RegraNomeTurma();

            RuleFor(p => p.Ano)
                .RegraAno();

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O identificador da turma não foi enviado.");
        }
    }
}
