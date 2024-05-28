using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Turmas.ObterTodas
{
    public class ObterTodasTurmasQueryHandler : BaseQueryHandler<ObterTodasTurmasQuery, IEnumerable<TurmaDTO>>
    {
        private ITurmaRepository _repository;

        public ObterTodasTurmasQueryHandler(IMediatorHandler mediator, ITurmaRepository repository) : base(mediator)
        {
            _repository = repository;
        }

        public async override Task<IEnumerable<TurmaDTO>> Handle(ObterTodasTurmasQuery request, CancellationToken cancellationToken)
        {
            var turmas = await _repository.ObterTodos();

            return turmas.Select(t => new TurmaDTO(t));
        }
    }
}
