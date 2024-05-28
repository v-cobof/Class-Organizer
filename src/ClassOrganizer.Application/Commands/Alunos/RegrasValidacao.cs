using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos
{
    public static class RegrasValidacao
    {
        public static IRuleBuilderOptions<T, string> RegraNome<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty()
                    .WithMessage("O nome do aluno deve ser preenchido.")
                    .Length(1, 255)
                    .WithMessage("O nome deve conter entre 1 e 255 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> RegraUsuario<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty()
                    .WithMessage("O usuário do aluno deve ser preenchido.")
                    .Length(1, 45)
                    .WithMessage("O usuário deve conter entre 1 e 45 caracteres.");
        }

        public static IRuleBuilderOptions<T, string> RegraSenha<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty().WithMessage("A senha deve ser preenchida.")
                    .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
                    .MaximumLength(30).WithMessage("A senha deve ter no máximo 30 caracteres.")
                    .Matches(@"[A-Z]").WithMessage("A senha deve ter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]").WithMessage("A senha deve ter pelo menos uma letra minúscula.")
                    .Matches(@"[0-9]").WithMessage("A senha deve ter pelo menos um número.")
                    .Matches(@"[\W]").WithMessage("A senha deve ter pelo menos um caracter especial.");
        }

        public static IRuleBuilderOptions<T, int> RegraId<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                    .GreaterThan(0).WithMessage("O identificador do aluno não foi enviado.");
        }
    }
}
