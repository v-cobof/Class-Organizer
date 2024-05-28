using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Alunos.ObterPorId
{
    public class ObterAlunoPorIdQueryHandler : BaseQueryHandler<ObterAlunoPorIdQuery, AlunoDTO>
    {
        private IAlunoRepository _repository;

        public ObterAlunoPorIdQueryHandler(IMediatorHandler mediator, IAlunoRepository repository) : base(mediator)
        {
            _repository = repository;
        }

        public async override Task<AlunoDTO> Handle(ObterAlunoPorIdQuery request, CancellationToken cancellationToken)
        {
            var aluno = await _repository.ObterPorId(request.Id);

            if (aluno is null)
            {
                await Notificar("O aluno não foi encontrado.");

                return default;
            }

            return new AlunoDTO(aluno);              
        }
    }
}
