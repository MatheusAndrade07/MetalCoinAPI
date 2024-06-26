using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MetalCoin.Infra.Data.Repositories
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntidade> DbSet;

        public Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntidade>();
        }
        public virtual async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await Salvar();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await Salvar();
        }

        public virtual async Task<TEntidade> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntidade { Id = id });
            await Salvar();
        }

        public async Task<int> Salvar()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
