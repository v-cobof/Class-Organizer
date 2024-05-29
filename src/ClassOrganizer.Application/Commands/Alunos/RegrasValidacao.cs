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
        public static string ERRO_NOME_VAZIO = "O nome do aluno deve ser preenchido.";
        public static string ERRO_NOME_INVALIDO = "O nome deve conter entre 1 e 255 caracteres.";

        public static string ERRO_USUARIO_VAZIO = "O usuário do aluno deve ser preenchido.";
        public static string ERRO_USUARIO_INVALIDO = "O usuário deve conter entre 1 e 45 caracteres.";

        public static string ERRO_SENHA_VAZIA = "A senha deve ser preenchida.";
        public static string ERRO_SENHA_MINIMA = "A senha deve ter pelo menos 6 caracteres.";
        public static string ERRO_SENHA_MAXIMO = "A senha deve ter no máximo 30 caracteres.";
        public static string ERRO_SENHA_MAIUSCULA = "A senha deve ter pelo menos uma letra maiúscula.";
        public static string ERRO_SENHA_MINUSCULA = "A senha deve ter pelo menos uma letra minúscula.";
        public static string ERRO_SENHA_NUMERO = "A senha deve ter pelo menos um número.";
        public static string ERRO_SENHA_ESPECIAL = "A senha deve ter pelo menos um caracter especial.";

        public static IRuleBuilderOptions<T, string> RegraNome<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty()
                    .WithMessage(ERRO_NOME_VAZIO)
                    .Length(1, 255)
                    .WithMessage(ERRO_NOME_INVALIDO);
        }

        public static IRuleBuilderOptions<T, string> RegraUsuario<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty()
                    .WithMessage(ERRO_USUARIO_VAZIO)
                    .Length(1, 45)
                    .WithMessage(ERRO_USUARIO_INVALIDO);
        }

        public static IRuleBuilderOptions<T, string> RegraSenha<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .NotEmpty().WithMessage(ERRO_SENHA_VAZIA)
                    .MinimumLength(6).WithMessage(ERRO_SENHA_MINIMA)
                    .MaximumLength(30).WithMessage(ERRO_SENHA_MAXIMO)
                    .Matches(@"[A-Z]").WithMessage(ERRO_SENHA_MAIUSCULA)
                    .Matches(@"[a-z]").WithMessage(ERRO_SENHA_MINUSCULA)
                    .Matches(@"[0-9]").WithMessage(ERRO_SENHA_NUMERO)
                    .Matches(@"[\W]").WithMessage(ERRO_SENHA_ESPECIAL);
        }

        public static IRuleBuilderOptions<T, int> RegraId<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                    .GreaterThan(0).WithMessage("O identificador do aluno não foi enviado.");
        }
    }
}
