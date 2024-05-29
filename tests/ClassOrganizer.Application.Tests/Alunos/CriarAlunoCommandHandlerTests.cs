using ClassOrganizer.Application.Commands.Alunos.Criar;
using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Tests.Alunos
{
    public class CriarAlunoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CriarAlunoCommandHandler _handler;

        public CriarAlunoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _handler = _mocker.CreateInstance<CriarAlunoCommandHandler>();
        }

        [Fact]
        public async void CriarAluno_AlunoValido_DeveExecutarComSucesso()
        {
            // Arrange
            var comando = new CriarAlunoCommand()
            {
                Nome = Guid.NewGuid().ToString(),
                Senha = "Abc@12345",
                Usuario = Guid.NewGuid().ToString(),
            };

            _mocker.GetMock<IAlunoRepository>().Setup(t => t.Criar(It.IsAny<Aluno>())).Returns(Task.FromResult(true));
            _mocker.GetMock<IHashingService>().Setup(t => t.CriarHash(It.IsAny<string>())).Returns(Guid.NewGuid().ToString());

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Sucesso());
            _mocker.GetMock<IHashingService>().Verify(r => r.CriarHash(It.IsAny<string>()), Times.Once);
            _mocker.GetMock<IAlunoRepository>().Verify(r => r.Criar(It.IsAny<Aluno>()), Times.Once);
        }

        [Fact]
        public async void CriarAluno_ProblemaCriarHash_DeveFalhar()
        {
            // Arrange
            var comando = new CriarAlunoCommand()
            {
                Nome = Guid.NewGuid().ToString(),
                Senha = "Abc@12345",
                Usuario = Guid.NewGuid().ToString(),
            };

            _mocker.GetMock<IHashingService>().Setup(t => t.CriarHash(It.IsAny<string>())).Returns($"{Guid.NewGuid()}{Guid.NewGuid()}{Guid.NewGuid()}");

            // Act
            var result = await _handler.Handle(comando, CancellationToken.None);

            // Assert
            Assert.Equal(result, CommandResult.Falha());
            _mocker.GetMock<IMediatorHandler>().Verify(m => m.PublishNotification(It.IsAny<DomainNotification>()), Times.Once);
            _mocker.GetMock<IHashingService>().Verify(r => r.CriarHash(It.IsAny<string>()), Times.Once);
            _mocker.GetMock<IAlunoRepository>().Verify(r => r.Criar(It.IsAny<Aluno>()), Times.Never);
        }
    }
}
