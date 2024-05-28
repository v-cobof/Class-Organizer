using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Turmas.ObterPorId
{
    public class ObterTurmaPorIdQueryHandler : BaseQueryHandler<ObterTurmaPorIdQuery, TurmaDTO>
    {
        private ITurmaRepository _repository;

        public ObterTurmaPorIdQueryHandler(IMediatorHandler mediator, ITurmaRepository repository) : base(mediator)
        {
            _repository = repository;
        }

        public async override Task<TurmaDTO> Handle(ObterTurmaPorIdQuery request, CancellationToken cancellationToken)
        {
            var turma = await _repository.ObterPorId(request.Id);

            if (turma is null)
            {
                await Notificar("A turma não foi encontrada.");

                return default;
            }

            return new TurmaDTO()
            {
                Id = turma.Id,
                Ano = turma.Ano,
                CursoId = turma.CursoId,
                NomeTurma = turma.NomeTurma,
            };
        }
    }
}
