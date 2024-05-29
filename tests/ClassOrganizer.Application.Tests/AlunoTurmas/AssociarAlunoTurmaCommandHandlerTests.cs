using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using Moq.AutoMock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassOrganizer.Application.Commands.AlunosTurmas.Associar;
using ClassOrganizer.Domain.Entidades;

namespace ClassOrganizer.Application.Tests.AlunoTurmas
{
    public class AssociarAlunoTurmaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AssociarAlunoTurmaCommandHandler _handler;

        public AssociarAlunoTurmaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _handler = _mocker.CreateInstance<AssociarAlunoTurmaCommandHandler>();
        }

        [Fact]
        public async void AssociarAlunoTurma_AlunoJaAssociadoATurma_DeveFalharEGerarNotificacao()
        {
            // Arrange
            var comando = new AssociarAlunoTurmaCommand()
            {
                AlunoId = 12,
                TurmaId = 21
            };

            _mocker.GetMock<ITurmaRepository>().Setup(t => t.ObterPorId(comando.TurmaId)).Returns(Task.FromResult(new Turma()));
            _mocker.GetMock<IAlunoRepository>().Setup(t => t.ObterPorId(comando.AlunoId)).Returns(Task.FromResult(new Aluno()));
            _mocker.GetMock<IAlunoRepository>().Setup(t => t.ObterAlunoPorIdETurma(comando.AlunoId, comando.TurmaId)).Returns(Task.FromResult(new Domain.Entidades.Aluno()));

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Falha());
            _mocker.GetMock<IMediatorHandler>().Verify(m => m.PublishNotification(It.IsAny<DomainNotification>()), Times.Once);
            _mocker.GetMock<ITurmaRepository>().Verify(r => r.AssociarAlunoATurma(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async void AssociarAlunoTurma_AlunoNovo_DeveExecutarComSucesso()
        {
            // Arrange
            var comando = new AssociarAlunoTurmaCommand()
            {
                AlunoId = 12,
                TurmaId = 21
            };

            _mocker.GetMock<ITurmaRepository>().Setup(t => t.ObterPorId(comando.TurmaId)).Returns(Task.FromResult(new Turma()));
            _mocker.GetMock<ITurmaRepository>().Setup(t => t.AssociarAlunoATurma(comando.AlunoId, comando.TurmaId)).Returns(Task.FromResult(true));
            _mocker.GetMock<IAlunoRepository>().Setup(t => t.ObterPorId(comando.AlunoId)).Returns(Task.FromResult(new Aluno()));
            _mocker.GetMock<IAlunoRepository>().Setup(t => t.ObterAlunoPorIdETurma(comando.AlunoId, comando.TurmaId)).Returns(Task.FromResult<Aluno>(null));

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Sucesso());
            _mocker.GetMock<IMediatorHandler>().Verify(m => m.PublishNotification(It.IsAny<DomainNotification>()), Times.Never);
            _mocker.GetMock<ITurmaRepository>().Verify(r => r.AssociarAlunoATurma(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
