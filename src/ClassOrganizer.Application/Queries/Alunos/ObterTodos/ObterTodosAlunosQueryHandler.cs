using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Alunos.ObterTodos
{
    public class ObterTodosAlunosQueryHandler : BaseQueryHandler<ObterTodosAlunosQuery, IEnumerable<AlunoDTO>>
    {
        private IAlunoRepository _repository;

        public ObterTodosAlunosQueryHandler(IMediatorHandler mediator, IAlunoRepository repository) : base(mediator)
        {
            _repository = repository;
        }

        public async override Task<IEnumerable<AlunoDTO>> Handle(ObterTodosAlunosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await _repository.ObterTodos();

            return alunos.Select(t => new AlunoDTO(t));
        }
    }
}
