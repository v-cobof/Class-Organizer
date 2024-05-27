using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> CreateAsync<T>(T entity, string insertQuery)
        {
            using (var connection = CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(insertQuery, entity);
                return id;
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

        public async Task<int> UpdateAsync<T>(T entity, string updateQuery)
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(updateQuery, entity);
                return rowsAffected;
            }
        }

        public async Task<int> DeleteAsync(int id, string deleteQuery)
        {
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(deleteQuery, new { Id = id });
                return rowsAffected;
            }
        }
    }
}
