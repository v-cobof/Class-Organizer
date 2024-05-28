using ClassOrganizer.Application.Commands.Turmas.Criar;
using ClassOrganizer.Application.Commands.Turmas.Editar;
using ClassOrganizer.Application.Commands.Turmas.Inativar;
using ClassOrganizer.Application.DTO;
using ClassOrganizer.Application.Queries.Turmas.ObterPorId;
using ClassOrganizer.Application.Queries.Turmas.ObterTodas;
using ClassOrganizer.Domain.Core.Comunicacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassOrganizer.API.Controllers
{
    [ApiController]
    [Route("api/turmas")]
    public class TurmasController : AbstractController
    {
        public TurmasController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaDTO>> ObterTurmaPorId(int id)
        {
            var query = new ObterTurmaPorIdQuery()
            {
                Id = id
            };

            return await EnviarQuery(query);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurmaDTO>>> ObterTodasTurmas()
        {
            var query = new ObterTodasTurmasQuery();

            return await EnviarQuery(query);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CriarTurma([FromBody] CriarTurmaCommand criarTurmaCommand)
        {
            return await EnviarComando(criarTurmaCommand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditarTurma(int id, [FromBody] EditarTurmaCommand editarTurmaCommand)
        {
            editarTurmaCommand.Id = id;

            return await EnviarComando(editarTurmaCommand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirTurma(int id)
        {
            var comando = new InativarTurmaCommand()
            {
                Id = id
            };

            return await EnviarComando(comando);
        }
    }
}
