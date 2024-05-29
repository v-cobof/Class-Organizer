using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;

namespace ClassOrganizer.Application.Commands.AlunosTurmas.Associar
{
    public class AssociarAlunoTurmaCommandHandler : BaseCommandHandler<AssociarAlunoTurmaCommand>
    {
        private IAlunoRepository _alunoRepository;
        private ITurmaRepository _turmaRepository;

        public AssociarAlunoTurmaCommandHandler(IMediatorHandler mediator, ITurmaRepository turmaRepository, IAlunoRepository alunoRepo) : base(mediator)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepo;
        }

        public async override Task<CommandResult> Handle(AssociarAlunoTurmaCommand request, CancellationToken cancellationToken)
        {
            if (await _alunoRepository.ObterPorId(request.AlunoId) is null)
            {
                await Notificar("O aluno não foi encontrado.");
                return CommandResult.Falha();
            }

            if (await _turmaRepository.ObterPorId(request.TurmaId) is null)
            {
                await Notificar("A turma não foi encontrada.");
                return CommandResult.Falha();
            }

            if (await AlunoJaEstaNaTurma(request.AlunoId, request.TurmaId))
            {
                await Notificar("O aluno já foi associado a turma.");
                return CommandResult.Falha();
            }

            return await _turmaRepository.AssociarAlunoATurma(request.AlunoId, request.TurmaId);
        }

        private async Task<bool> AlunoJaEstaNaTurma(int alunoId, int turmaId)
        {
            var aluno = await _alunoRepository.ObterAlunoPorIdETurma(alunoId, turmaId);

            return aluno != null;
        }
    }
}
