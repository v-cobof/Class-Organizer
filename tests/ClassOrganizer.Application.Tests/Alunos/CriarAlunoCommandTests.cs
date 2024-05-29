using ClassOrganizer.Application.Commands.Alunos;
using ClassOrganizer.Application.Commands.Alunos.Criar;
using ClassOrganizer.Application.Commands.Alunos.CriarAluno;

namespace ClassOrganizer.Application.Tests.Alunos
{
    public class CriarAlunoCommandTests
    {
        [Fact]
        public void CriarAlunoCommand_ComandoInvalido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var comando = new CriarAlunoCommand()
            {
                Nome = string.Empty,
                Senha = string.Empty,
                Usuario = string.Empty,
            };
            var validacao = new CriarAlunoCommandValidation();

            // Act
            var result = validacao.Validate(comando);
            var erros = result.Errors.Select(t => t.ErrorMessage).ToArray();

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(RegrasValidacao.ERRO_NOME_VAZIO, erros);
            Assert.Contains(RegrasValidacao.ERRO_NOME_INVALIDO, erros);

            Assert.Contains(RegrasValidacao.ERRO_USUARIO_INVALIDO, erros);
            Assert.Contains(RegrasValidacao.ERRO_USUARIO_VAZIO, erros);

            Assert.Contains(RegrasValidacao.ERRO_SENHA_ESPECIAL, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_MAIUSCULA, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_MINIMA, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_MINUSCULA, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_NUMERO, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_VAZIA, erros);
        }

        [Fact]
        public void CriarAlunoCommand_ComandoSenhaMuitoGrande_NaoDevePassarNaValidacao()
        {
            // Arrange
            var comando = new CriarAlunoCommand()
            {
                Nome = string.Empty,
                Senha = "sssssssssssssssssssssssssssssssssssssssssssss",
                Usuario = string.Empty,
            };
            var validacao = new CriarAlunoCommandValidation();

            // Act
            var result = validacao.Validate(comando);
            var erros = result.Errors.Select(t => t.ErrorMessage).ToArray();

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(RegrasValidacao.ERRO_NOME_VAZIO, erros);
            Assert.Contains(RegrasValidacao.ERRO_NOME_INVALIDO, erros);

            Assert.Contains(RegrasValidacao.ERRO_USUARIO_INVALIDO, erros);
            Assert.Contains(RegrasValidacao.ERRO_USUARIO_VAZIO, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_MAXIMO, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_ESPECIAL, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_MAIUSCULA, erros);
            Assert.Contains(RegrasValidacao.ERRO_SENHA_NUMERO, erros);
        }

        [Fact]
        public void CriarAlunoCommand_ComandoValido_DevePassarNaValidacao()
        {
            // Arrange
            var comando = new CriarAlunoCommand()
            {
                Nome = Guid.NewGuid().ToString(),
                Senha = "Abc@12345",
                Usuario = Guid.NewGuid().ToString(),
            };
            var validacao = new CriarAlunoCommandValidation();

            // Act
            var result = validacao.Validate(comando);
            var erros = result.Errors.Select(t => t.ErrorMessage).ToArray();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(erros);
        }
    }
}