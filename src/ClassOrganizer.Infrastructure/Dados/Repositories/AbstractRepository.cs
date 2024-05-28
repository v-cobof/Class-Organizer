using ClassOrganizer.Domain.Core;
using ClassOrganizer.Domain.Core.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Infrastructure.Dados.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entidade
    {
        protected readonly DbContext _dbContext;
        protected abstract string Tabela { get; }

        public AbstractRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract Task<bool> Atualizar(T entity);

        public abstract Task<bool> Criar(T entity);

        public abstract Task<bool> Excluir(T entity);

        public abstract Task<T> ObterPorId(int id);

        public abstract Task<IEnumerable<T>> ObterTodos();
    }
}
