using ClassOrganizer.Application.Commands.Alunos.CriarAluno;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Core.Services;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Infrastructure.CrossCutting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Tests.Alunos
{
    public class HashTests
    {
        [Theory]
        [InlineData("Abc@1234567", "hFRBfPVo2oRGsWUCBD56wCWHNgixWjmy5Y0TIVA/dPU=")]
        public void CriarHash_SenhaValida_DeveCriarHashCorreto(string senhaAntes, string senhaDepois)
        {
            // Arrange
            var hasher = new HashService();

            // Act
            var result = hasher.CriarHash(senhaAntes);

            // Assert
            Assert.Equal(senhaDepois, result);
        }
    }
}
