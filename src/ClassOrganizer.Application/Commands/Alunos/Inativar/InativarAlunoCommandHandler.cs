using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Inativar
{
    public class InativarAlunoCommandHandler : BaseCommandHandler<InativarAlunoCommand>
    {
        private readonly IAlunoRepository _repository;

        public InativarAlunoCommandHandler(IMediatorHandler mediator, IAlunoRepository repo) : base(mediator)
        {
            _repository = repo;
        }

        public async override Task<CommandResult> Handle(InativarAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _repository.ObterPorId(request.Id);

            if (aluno is null)
            {
                await Notificar("O aluno não foi encontrado.");
                return CommandResult.Falha();
            }

            return await _repository.Excluir(aluno);
        }
    }
}
