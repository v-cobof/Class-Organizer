using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.Commands.Alunos.CriarAluno
{
    public class CriarAlunoCommandHandler : BaseCommandHandler<CriarAlunoCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IHashingService _hashingService;
        private int TAMANHO_MAXIMO_SENHA = 60;

        public CriarAlunoCommandHandler(IMediatorHandler mediator, IAlunoRepository repo, IHashingService hashingService) : base(mediator)
        {
            _repository = repo;
            _hashingService = hashingService;
        }

        public async override Task<CommandResult> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _hashingService.CriarHash(request.Senha);

            if (senhaHash.Length > TAMANHO_MAXIMO_SENHA)
            {
                await Notificar("A senha escolhida é inválida.");
                return CommandResult.Falha();
            }

            var aluno = new Aluno(request.Nome, request.Usuario, senhaHash);

            return await _repository.Criar(aluno);
        }
    }
}
