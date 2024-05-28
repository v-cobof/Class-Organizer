using ClassOrganizer.Domain.Core.Dados;
using ClassOrganizer.Domain.Dados;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace ClassOrganizer.Infrastructure.Dados.Repositories
{
    public class TurmaRepository : AbstractRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override string Tabela => "turma";

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

        public async override Task<Turma> ObterPorId(int id)
        {
            var sql = $@"SELECT [id],
                            curso_id AS [CursoId], 
                            turma AS [NomeTurma], 
                            ano AS [Ano] 
                        FROM {Tabela} 
                        WHERE id = @id";

            return await _dbContext.GetByIdAsync<Turma>(id, sql);
        }

        public async Task<Turma> ObterPorNomeTurma(string nomeTurma)
        {
            var sql = @"SELECT [id],
                            curso_id AS [CursoId], 
                            turma AS [NomeTurma], 
                            ano AS [Ano] 
                        FROM aluno 
                        WHERE turma = @nomeTurma";

            using var connection = _dbContext.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Turma>(sql, new { nomeTurma = nomeTurma });
        }

        public async override Task<IEnumerable<Turma>> ObterTodos()
        {
            var sql = $@"
                SELECT [id],
                    curso_id AS [CursoId], 
                    turma AS [NomeTurma], 
                    ano AS [Ano] 
                FROM {Tabela} 
                WHERE id = @id";

            return await _dbContext.GetAllAsync<Turma>(sql);
        }
    }
}
