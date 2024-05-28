using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.Commands.Turmas.Inativar
{
    public class InativarTurmaCommandHandler : BaseCommandHandler<InativarTurmaCommand>
    {
        private ITurmaRepository _repository;

        public InativarTurmaCommandHandler(IMediatorHandler mediator, ITurmaRepository repo) : base(mediator)
        {
            _repository = repo;
        }

        public async override Task<CommandResult> Handle(InativarTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = await _repository.ObterPorId(request.Id);

            if (turma is null)
            {
                await Notificar("A turma não foi encontrada.");
                return CommandResult.Falha();
            }

            return await _repository.Excluir(turma);
        }
    }
}
