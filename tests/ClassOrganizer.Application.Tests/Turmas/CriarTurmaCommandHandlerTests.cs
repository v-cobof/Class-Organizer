using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Application.Commands.Turmas.Criar;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using MediatR;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Tests.Turmas
{
    public class CriarTurmaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CriarTurmaCommandHandler _handler;

        public CriarTurmaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _handler = _mocker.CreateInstance<CriarTurmaCommandHandler>();
        }

        [Fact]
        public async void CriarTurma_TurmaNomeRepetido_DeveFalharEGerarNotificacao()
        {
            // Arrange
            var comando = new CriarTurmaCommand()
            {
                NomeTurma = Guid.NewGuid().ToString(),
                CursoId = 123,
                Ano = 2024
            };

            _mocker.GetMock<ITurmaRepository>().Setup(t => t.ObterPorNomeTurma(comando.NomeTurma)).Returns(Task.FromResult(new Turma()));

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Falha());
            _mocker.GetMock<IMediatorHandler>().Verify(m => m.PublishNotification(It.IsAny<DomainNotification>()), Times.Once);
            _mocker.GetMock<ITurmaRepository>().Verify(r => r.Criar(It.IsAny<Turma>()), Times.Never);
        }

        [Fact]
        public async void CriarTurma_TurmaCorreta_DeveExecutarComSucesso()
        {
            // Arrange
            var comando = new CriarTurmaCommand()
            {
                NomeTurma = Guid.NewGuid().ToString(),
                CursoId = 123,
                Ano = 2024
            };

            _mocker.GetMock<ITurmaRepository>().Setup(t => t.ObterPorNomeTurma(comando.NomeTurma)).Returns(Task.FromResult<Turma>(null));
            _mocker.GetMock<ITurmaRepository>().Setup(t => t.Criar(It.IsAny<Turma>())).Returns(Task.FromResult(true));

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Sucesso());
            _mocker.GetMock<IMediatorHandler>().Verify(m => m.PublishNotification(It.IsAny<DomainNotification>()), Times.Never);
            _mocker.GetMock<ITurmaRepository>().Verify(r => r.Criar(It.IsAny<Turma>()), Times.Once);
        }
    }
}
