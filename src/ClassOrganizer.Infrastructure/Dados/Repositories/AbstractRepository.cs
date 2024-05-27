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

        public abstract Task Atualizar(T entity);

        public abstract Task Criar(T entity);

        public abstract Task Excluir(T entity);

        public abstract Task<T> ObterPorId(int id);
    }
}
