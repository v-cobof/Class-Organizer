using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClassOrganizer.Domain.Core;
using Dapper;

namespace ClassOrganizer.Infrastructure.Dados
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<bool> CreateAsync<T>(T entity, string insertQuery) where T : Entidade
        {
            using (var connection = CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(insertQuery, entity);

                entity.Id = id;

                return id > 0;
            }
        }

        public async Task<T> GetByIdAsync<T>(int id, string selectQuery)
        {
            using (var connection = CreateConnection())
            {
                var entity = await connection.QuerySingleOrDefaultAsync<T>(selectQuery, new { Id = id });
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string selectQuery)
        {
            using (var connection = CreateConnection())
            {
                var entities = await connection.QueryAsync<T>(selectQuery);
                return entities;
            }
        }

        public async Task<bool> UpdateAsync<T>(T entity, string updateQuery) where T : Entidade
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(updateQuery, entity);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id, string deleteQuery)
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(deleteQuery, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
