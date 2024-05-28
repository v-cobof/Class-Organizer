using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;

namespace ClassOrganizer.Application.Queries.AlunosTurmas.ObterTodosAlunosNaTurma
{
    public class ObterTodosAlunosNaTurmaQueryHandler : BaseQueryHandler<ObterTodosAlunosNaTurmaQuery, IEnumerable<AlunoDTO>>
    {
        private readonly IAlunoRepository _repository;

        public ObterTodosAlunosNaTurmaQueryHandler(IMediatorHandler mediator, IAlunoRepository repo) : base(mediator)
        {
            _repository = repo;
        }

        public async override Task<IEnumerable<AlunoDTO>> Handle(ObterTodosAlunosNaTurmaQuery request, CancellationToken cancellationToken)
        {
            var alunos = await _repository.ObterTodosAlunoNaTurma(request.TurmaId);

            return alunos.Select(t => new AlunoDTO(t));
        }
    }
}
