using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.CriarAluno
{
    public class CriarAlunoCommandHandler : BaseCommandHandler<CriarAlunoCommand>
    {
        public CriarAlunoCommandHandler(IMediatorHandler mediator) : base(mediator)
        {
        }

        public override Task<CommandResult> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
