using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.Commands.Turmas.Editar
{
    public class EditarTurmaCommandHandler : BaseCommandHandler<EditarTurmaCommand>
    {
        private ITurmaRepository _repository;

        public EditarTurmaCommandHandler(IMediatorHandler mediator, ITurmaRepository repo) : base(mediator)
        {
            _repository = repo;
        }

        public async override Task<CommandResult> Handle(EditarTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = await _repository.ObterPorId(request.Id);

            if (turma is null)
            {
                await Notificar("A turma não foi encontrada");
                return CommandResult.Falha();
            }

            if (!string.Equals(turma.NomeTurma, request.NomeTurma, StringComparison.CurrentCultureIgnoreCase))
            {
                var turmaNome = await _repository.ObterPorNomeTurma(request.NomeTurma);

                if (turmaNome != null)
                {
                    await Notificar("Já existe uma turma com o nome escolhido.");
                    return CommandResult.Falha();
                }
            }

            turma.AtualizarCursoId(request.CursoId);
            turma.AtualizarNomeTurma(request.NomeTurma);
            turma.AtualizarAno(request.Ano);

            return await _repository.Atualizar(turma);
        }
    }
}
