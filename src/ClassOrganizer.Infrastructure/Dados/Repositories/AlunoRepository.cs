using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using Dapper;
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
            var sql = $@"UPDATE {Tabela} 
                SET 
                    nome = @Nome, 
                    usuario = @Usuario, 
                    senha = @Senha 
                WHERE id = @Id";

            return await _dbContext.UpdateAsync(entity, sql);
        }

        public async override Task<bool> Criar(Aluno entity)
        {
            var sql = $@"INSERT INTO {Tabela} (nome, usuario, senha)
                OUTPUT INSERTED.id
                VALUES (@Nome, @Usuario, @Senha)";

            return await _dbContext.CreateAsync(entity, sql);
        }

        public async override Task<bool> Excluir(Aluno entity)
        {
            var sql = $@"DELETE FROM {Tabela} WHERE id = @id";

            return await _dbContext.DeleteAsync(entity.Id, sql);
        }

        public async Task<Aluno> ObterAlunoPorIdETurma(int id, int turmaId)
        {
            var sql = $@"SELECT  
                    aluno.id as [Id],
                    aluno.nome AS [Nome], 
                    aluno.usuario AS [Usuario], 
                    aluno.senha AS [Senha] 
                FROM aluno_turma
                JOIN aluno ON aluno.id = aluno_turma.aluno_id
                JOIN turma ON turma.id = aluno_turma.turma_id
                WHERE turma.id = @turmaId
                AND aluno.id = @id
            ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Aluno>(sql, new { turmaId, id });
        }

        public async override Task<Aluno> ObterPorId(int id)
        {
            var sql = $@"SELECT [id],
                    nome AS [Nome], 
                    usuario AS [Usuario], 
                    senha AS [Senha] 
                FROM {Tabela} 
                WHERE id = @id";

            return await _dbContext.GetByIdAsync<Aluno>(id, sql);
        }

        public async override Task<IEnumerable<Aluno>> ObterTodos()
        {
            var sql = $@"SELECT 
                    id AS [Id],
                    nome AS [Nome], 
                    usuario AS [Usuario], 
                    senha AS [Senha] 
                FROM {Tabela}";

            return await _dbContext.GetAllAsync<Aluno>(sql);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAlunoNaTurma(int turmaId)
        {
            var sql = $@"SELECT  
                    aluno.id as [Id],
                    aluno.nome AS [Nome], 
                    aluno.usuario AS [Usuario], 
                    aluno.senha AS [Senha] 
                FROM aluno_turma
                JOIN aluno ON aluno.id = aluno_turma.aluno_id
                JOIN turma ON turma.id = aluno_turma.turma_id
                WHERE turma.id = @turmaId
            ";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryAsync<Aluno>(sql, new { turmaId });
        }
    }
}
