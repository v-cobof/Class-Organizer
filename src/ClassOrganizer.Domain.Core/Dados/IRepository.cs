namespace ClassOrganizer.Domain.Core.Dados
{
    public interface IRepository<T> where T : Entidade
    {
        Task<T> ObterPorId(int id);
        Task<IEnumerable<T>> ObterTodos();
        Task<bool> Criar(T entity);
        Task<bool> Atualizar(T entity);
        Task<bool> Excluir(T entity);
    }
}
