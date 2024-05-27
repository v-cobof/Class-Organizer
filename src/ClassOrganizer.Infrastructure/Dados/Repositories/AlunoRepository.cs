using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Infrastructure.Dados.Repositories
{
    public class AlunoRepository : AbstractRepository<Aluno>, IAlunoRepository
    {
        protected override string Tabela => "aluno";

        public async override Task Atualizar(Aluno entity)
        {
            await _dbContext.UpdateAsync(entity, "");
        }

        public async override Task Criar(Aluno entity)
        {
            var sqlQuery = $@"
                INSERT INTO {Tabela} (nome, usuario, senha)
                OUTPUT INSERTED.id
                VALUES (@Nome, @Usuario, @Senha)";

            await _dbContext.CreateAsync(entity, sqlQuery);
        }

        public override Task Excluir(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Aluno> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
