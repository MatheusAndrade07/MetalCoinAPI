using Metalcoin.Core.Abstracts;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entidade
    {
        Task Adicionar(TEntity entidade);
        Task Atualizar(TEntity entidade);
        Task Remover(Guid id);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<int> Salvar();
    }
}
