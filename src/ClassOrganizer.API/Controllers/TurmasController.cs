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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurmaDTO>> ObterTurmaPorId(int id)
        {
            var query = new ObterTurmaPorIdQuery()
            {
                Id = id
            };

            return await EnviarQuery(query);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TurmaDTO>>> ObterTodasTurmas()
        {
            var query = new ObterTodasTurmasQuery();

            return await EnviarQuery(query);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CriarTurma([FromBody] CriarTurmaCommand criarTurmaCommand)
        {
            return await EnviarComando(criarTurmaCommand);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditarTurma(int id, [FromBody] EditarTurmaCommand editarTurmaCommand)
        {
            editarTurmaCommand.Id = id;

            return await EnviarComando(editarTurmaCommand);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
