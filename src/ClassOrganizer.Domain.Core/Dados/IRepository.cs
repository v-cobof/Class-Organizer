namespace ClassOrganizer.Domain.Core.Dados
{
    public interface IRepository<T> where T : Entidade
    {
        Task<T> ObterPorId(int id);
        void Criar(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
    }
}
