using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Commands.Alunos.Editar
{
    public class EditarAlunoCommandHandler : BaseCommandHandler<EditarAlunoCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IHashingService _hashingService;

        public EditarAlunoCommandHandler(IMediatorHandler mediator, IAlunoRepository repo, IHashingService hashingService) : base(mediator)
        {
            _repository = repo;
            _hashingService = hashingService;
        }

        public async override Task<CommandResult> Handle(EditarAlunoCommand request, CancellationToken cancellationToken)
        {
            var alunoBd = await _repository.ObterPorId(request.Id);

            if (alunoBd is null)
            {
                await Notificar("O aluno não foi encontrado.");
                return CommandResult.Falha();
            }

            alunoBd.AtualizarNome(request.Nome);
            alunoBd.AtualizarUsuario(request.Usuario);
            AtualizarSenha(request, alunoBd);

            return await _repository.Atualizar(alunoBd);
        }

        private void AtualizarSenha(EditarAlunoCommand request, Aluno alunoBd)
        {
            if (!string.IsNullOrEmpty(request.Senha))
            {
                var senhaHash = _hashingService.CriarHash(request.Senha);
                alunoBd.AtualizarSenha(senhaHash);
            }
        }
    }
}
