using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Application.Commands.Alunos.Editar;
using ClassOrganizer.Application.Commands.Alunos.Inativar;
using ClassOrganizer.Application.DTO;
using ClassOrganizer.Application.Queries.Alunos.ObterPorId;
using ClassOrganizer.Application.Queries.Alunos.ObterTodos;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassOrganizer.API.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : AbstractController
    {
        public AlunosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlunoDTO>> ObterAlunoPorId(int id)
        {
            var query = new ObterAlunoPorIdQuery()
            {
                Id = id
            };

            return await EnviarQuery(query);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AlunoMinDTO>>> ObterTodosAlunos()
        {
            var query = new ObterTodosAlunosQuery();

            return await EnviarQuery(query);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CriarAluno([FromBody] CriarAlunoCommand criarAlunoCommand)
        {
            return await EnviarComando(criarAlunoCommand);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditarAluno(int id, [FromBody] EditarAlunoCommand editarAlunoCommand)
        {
            editarAlunoCommand.Id = id;

            return await EnviarComando(editarAlunoCommand);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ExcluirAluno(int id)
        {
            var comando = new InativarAlunoCommand()
            {
                Id = id
            };

            return await EnviarComando(comando);
        }
    }
}
