using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Turmas.Criar
{
    public class CriarTurmaCommandValidation : AbstractValidator<CriarTurmaCommand>
    {
        public CriarTurmaCommandValidation()
        {
            RuleFor(p => p.CursoId)
                .RegraCurso();

            RuleFor(p => p.NomeTurma)
                .RegraNomeTurma();

            RuleFor(p => p.Ano)
                .RegraAno();
        }
    }
}
