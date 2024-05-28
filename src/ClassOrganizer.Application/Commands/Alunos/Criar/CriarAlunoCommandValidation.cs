using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Criar
{
    public class CriarAlunoCommandValidation : AbstractValidator<CriarAlunoCommand>
    {
        public CriarAlunoCommandValidation()
        {
            RuleFor(c => c.Nome)
                .RegraNome();

            RuleFor(c => c.Usuario)
                .RegraUsuario();

            RuleFor(x => x.Senha)
                .RegraSenha();
        }
    }
}
