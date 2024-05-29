using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;

namespace ClassOrganizer.Application.Queries.AlunosTurmas.ObterTodosAlunosNaTurma
{
    public class ObterTodosAlunosNaTurmaQueryHandler : BaseQueryHandler<ObterTodosAlunosNaTurmaQuery, IEnumerable<AlunoDTO>>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public ObterTodosAlunosNaTurmaQueryHandler(IMediatorHandler mediator, IAlunoRepository repo, ITurmaRepository repository) : base(mediator)
        {
            _alunoRepository = repo;
            _turmaRepository = repository;
        }

        public async override Task<IEnumerable<AlunoDTO>> Handle(ObterTodosAlunosNaTurmaQuery request, CancellationToken cancellationToken)
        {
            var turma = await _turmaRepository.ObterPorId(request.TurmaId);

            if (turma is null)
            {
                await Notificar("A turma não foi encontrada.");
                return null;
            }

            var alunos = await _alunoRepository.ObterTodosAlunoNaTurma(request.TurmaId);

            return alunos.Select(t => new AlunoDTO(t));
        }
    }
}
