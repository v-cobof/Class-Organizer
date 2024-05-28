using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Turmas
{
    public static class RegrasValidacao
    {
        public static IRuleBuilderOptions<T, int> RegraCurso<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                    .GreaterThan(0)
                    .WithMessage("O identificador do curso deve ser preenchido.");
        }

        public static IRuleBuilderOptions<T, string> RegraNomeTurma<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty().WithMessage("O Nome da Turma deve ser preenchido.")
                    .Length(1, 45).WithMessage("O Nome da Turma deve conter entre 1 e 45 caracteres");

        }

        public static IRuleBuilderOptions<T, int> RegraAno<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                    .InclusiveBetween(1970, DateTime.Now.Year)
                    .WithMessage($"O Ano deve ser um valor entre 1970 e {DateTime.Now.Year}.");
        }
    }
}
