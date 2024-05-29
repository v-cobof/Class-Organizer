using ClassOrganizer.Application.Commands.AlunosTurmas.Associar;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.AlunosTurmas.InativarAssociacao
{
    internal class InativarAssociacaoAlunoTurmaCommandHandler : BaseCommandHandler<InativarAssociacaoAlunoTurmaCommand>
    {
        private IAlunoRepository _alunoRepository;
        private ITurmaRepository _turmaRepository;

        public InativarAssociacaoAlunoTurmaCommandHandler(IMediatorHandler mediator, ITurmaRepository turmaRepository, IAlunoRepository alunoRepo) : base(mediator)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepo;
        }

        public async override Task<CommandResult> Handle(InativarAssociacaoAlunoTurmaCommand request, CancellationToken cancellationToken)
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

            if (await _alunoRepository.ObterAlunoPorIdETurma(request.AlunoId, request.TurmaId) is null)
            {
                await Notificar("O aluno não está associado a essa turma.");
                return CommandResult.Falha();
            }

            return await _turmaRepository.InativarAssociacaoAlunoATurma(request.AlunoId, request.TurmaId);
        }
    }
}
