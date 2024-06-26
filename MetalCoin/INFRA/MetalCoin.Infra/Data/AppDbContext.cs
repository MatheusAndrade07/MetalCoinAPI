using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace MetalCoin.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
        {
            //Desabilita o rastreamento de entidades para melhorar a performance da aplicação
            //O rastreamento de entidades é o recurso que permite que o Entity Framework Core
            //acompanhe as mudanças em entidades e as propague para o banco de dados
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        //DbSet é uma coleção de entidades que representa uma tabela
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        //O método OnModelCreating é chamado quando o modelo de dados
        //é criado pela primeira vez. Ele é chamado após o método
        //OnConfiguring e antes do método SaveChanges. Ele é usado
        //para configurar o modelo de dados, como mapear entidades
        //para tabelas, definir chaves primárias, chaves estrangeiras,
        //propriedades de navegação, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplica as configurações de mapeamento das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //Configuração de campos do tipo string para varchar(100)
            //isso é necessário porque o Entity Framework Core não suporta
            //mapeamento direto de string para varchar
            //o Entity Framework Core mapeia string para nvarchar   
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))
            {
                propriedade.SetColumnType("varchar(100)");
            }

            //Desabilita o cascade delete
            //um exemplo de cascade delete é quando deletamos um fornecedor
            //e todos os produtos relacionados a ele são deletados
            //com o cascade delete desabilitado, os produtos relacionados
            //ao fornecedor deletado terão o campo FornecedorId setado como null
            foreach (var relacionamento in
                     modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                relacionamento.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                         .Where(entry => entry.Entity.GetType()
                             .GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    //evita que a propriedade DataCadastro seja modificada
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
