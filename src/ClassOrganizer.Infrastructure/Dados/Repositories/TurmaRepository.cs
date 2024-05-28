using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using Dapper;

namespace ClassOrganizer.Infrastructure.Dados.Repositories
{
    public class TurmaRepository : AbstractRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override string Tabela => "turma";
        private string TabelaRelacao => "aluno_turma";

        public async Task<bool> AssociarAlunoATurma(int alunoId, int turmaId)
        {
            var sql = $@"INSERT INTO {TabelaRelacao} (turma_id, aluno_id)
                            VALUES (@turmaId, @alunoId)";

            using var connection = _dbContext.CreateConnection();

            var result = await connection.ExecuteAsync(sql, new { turmaId, alunoId });

            return result > 0;
        }

        public async override Task<bool> Atualizar(Turma entity)
        {
            var sql = $@"UPDATE {Tabela} SET 
                            curso_id = @CursoId, 
                            turma = @NomeTurma, 
                            ano = @Ano 
                        WHERE id = @Id";

            return await _dbContext.UpdateAsync(entity, sql);
        }

        public async override Task<bool> Criar(Turma entity)
        {
            var sql = $@"INSERT INTO {Tabela} 
                            (curso_id, turma, ano)
                        OUTPUT INSERTED.id VALUES 
                            (@CursoId, @NomeTurma, @Ano)";

            return await _dbContext.CreateAsync(entity, sql);
        }

        public async override Task<bool> Excluir(Turma entity)
        {
            var sql = $@"DELETE FROM {Tabela} WHERE id = @id";

            return await _dbContext.DeleteAsync(entity.Id, sql);
        }

        public async Task<bool> InativarAssociacaoAlunoATurma(int alunoId, int turmaId)
        {
            var sql = $@"DELETE FROM {TabelaRelacao} 
                            WHERE aluno_id = @alunoId 
                            AND turma_id = @turmaId";

            using var connection = _dbContext.CreateConnection();

            var result = await connection.ExecuteAsync(sql, new { alunoId, turmaId });

            return result > 0;
        }

        public async override Task<Turma> ObterPorId(int id)
        {
            var sql = $@"SELECT id AS [Id],
                            curso_id AS [CursoId], 
                            turma AS [NomeTurma], 
                            ano AS [Ano] 
                        FROM {Tabela} 
                        WHERE id = @id";

            return await _dbContext.GetByIdAsync<Turma>(id, sql);
        }

        public async Task<Turma> ObterPorNomeTurma(string nomeTurma)
        {
            var sql = $@"SELECT id AS [Id],
                            curso_id AS [CursoId], 
                            turma AS [NomeTurma], 
                            ano AS [Ano] 
                        FROM {Tabela} 
                        WHERE turma = @nomeTurma";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Turma>(sql, new { nomeTurma });
        }

        public async override Task<IEnumerable<Turma>> ObterTodos()
        {
            var sql = $@"SELECT 
                            id AS [Id],
                            curso_id AS [CursoId], 
                            turma AS [NomeTurma], 
                            ano AS [Ano] 
                        FROM {Tabela}";

            return await _dbContext.GetAllAsync<Turma>(sql);
        }
    }
}
