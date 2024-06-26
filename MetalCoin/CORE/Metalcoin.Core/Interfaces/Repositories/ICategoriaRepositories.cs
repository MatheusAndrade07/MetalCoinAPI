using Metalcoin.Core.Domain;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria>BuscarPorNome(string nome);
    }
}
