using FluentValidation;

namespace ClassOrganizer.Application.Commands.AlunosTurmas.InativarAssociacao
{
    public class InativarAssociacaoAlunoTurmaCommandValidation : AbstractValidator<InativarAssociacaoAlunoTurmaCommand>
    {
        public InativarAssociacaoAlunoTurmaCommandValidation()
        {
            RuleFor(t => t.AlunoId)
                .GreaterThan(0).WithMessage("O identificador do aluno não foi enviado.");

            RuleFor(t => t.TurmaId)
                .GreaterThan(0).WithMessage("O identificador da turma não foi enviado.");
        }
    }
}
