using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalCoin.Infra.Data.Mappings
{
    internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnType("bit")
                .IsRequired();

        }
    }
}
