using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.Commands.Turmas.Criar
{
    public class CriarTurmaCommandHandler : BaseCommandHandler<CriarTurmaCommand>
    {
        private ITurmaRepository _repository;

        public CriarTurmaCommandHandler(IMediatorHandler mediator, ITurmaRepository repo) : base(mediator)
        {
            _repository = repo;
        }

        public async override Task<CommandResult> Handle(CriarTurmaCommand request, CancellationToken cancellationToken)
        {
            var turmaNome = await _repository.ObterPorNomeTurma(request.NomeTurma);

            if (turmaNome != null)
            {
                await Notificar("Já existe uma turma com o nome escolhido.");
                return CommandResult.Falha();
            }

            var turma = new Turma(request.CursoId, request.NomeTurma, request.Ano);

            return await _repository.Criar(turma);
        }
    }
}
