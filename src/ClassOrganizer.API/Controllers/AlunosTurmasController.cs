using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Application.Commands.AlunosTurmas.Associar;
using ClassOrganizer.Application.Commands.AlunosTurmas.InativarAssociacao;
using ClassOrganizer.Application.Queries.AlunosTurmas.ObterTodosAlunosNaTurma;
using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassOrganizer.API.Controllers
{
    [ApiController]
    [Route("api/alunos-turmas")]
    public class AlunosTurmasController : AbstractController
    {
        public AlunosTurmasController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
        }

        [HttpGet("{turmaId}")]
        public async Task<ActionResult> ObterTodosAlunosNaTurma(int turmaId)
        {
            var query = new ObterTodosAlunosNaTurmaQuery()
            {
                TurmaId = turmaId
            };

            return await EnviarQuery(query);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AssociarAlunoTurma([FromBody] AssociarAlunoTurmaCommand associarAlunoTurmaCommand)
        {
            return await EnviarComando(associarAlunoTurmaCommand);
        }

        [HttpDelete("{idAluno}/{idTurma}")]
        public async Task<ActionResult> InativarAssociacaoAlunoTurma(int idAluno, int idTurma)
        {
            var comando = new InativarAssociacaoAlunoTurmaCommand()
            {
                AlunoId = idAluno,
                TurmaId = idTurma
            };             

            return await EnviarComando(comando);
        }
    }
}
