namespace ClassOrganizer.Domain.Core.Dados
{
    public interface IRepository<T> where T : Entidade
    {
        Task<T> ObterPorId(int id);
        Task Criar(T entity);
        Task Atualizar(T entity);
        Task Excluir(T entity);
    }
}
