using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Editar
{
    public class EditarAlunoCommandValidation : AbstractValidator<EditarAlunoCommand>
    {
        public EditarAlunoCommandValidation()
        {
            RuleFor(c => c.Nome)
                .RegraNome();

            RuleFor(c => c.Usuario)
                .RegraUsuario();

            RuleFor(x => x.Senha)
                .RegraSenha()
                .When(x => !string.IsNullOrEmpty(x.Senha));

            RuleFor(x => x.Id)
                .RegraId();
        }
    }
}
