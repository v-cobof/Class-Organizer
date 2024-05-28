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
        public AlunoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override string Tabela => "aluno";

        public async override Task<bool> Atualizar(Aluno entity)
        {
            var sql = $@"
                UPDATE {Tabela} 
                SET 
                    nome = @Nome, 
                    usuario = @Usuario, 
                    senha = @Senha 
                WHERE id = @Id";

            return await _dbContext.UpdateAsync(entity, sql);
        }

        public async override Task<bool> Criar(Aluno entity)
        {
            var sql = $@"
                INSERT INTO {Tabela} (nome, usuario, senha)
                OUTPUT INSERTED.id
                VALUES (@Nome, @Usuario, @Senha)";

            return await _dbContext.CreateAsync(entity, sql);
        }

        public async override Task<bool> Excluir(Aluno entity)
        {
            var sql = $@"
                DELETE FROM {Tabela} WHERE id = @id";

            return await _dbContext.DeleteAsync(entity.Id, sql);
        }

        public async override Task<Aluno> ObterPorId(int id)
        {
            var sql = $@"
                SELECT [id],
                    nome AS [Nome], 
                    usuario AS [Usuario], 
                    senha AS [Senha] 
                FROM {Tabela} 
                WHERE id = @id";

            return await _dbContext.GetByIdAsync<Aluno>(id, sql);
        }

        public async override Task<IEnumerable<Aluno>> ObterTodos()
        {
            var sql = $@"
                SELECT [id],
                    nome AS [Nome], 
                    usuario AS [Usuario], 
                    senha AS [Senha] 
                FROM {Tabela}";

            return await _dbContext.GetAllAsync<Aluno>(sql);
        }
    }
}
