using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalCoin.Infra.Data.Mappings
{
    internal class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Documento)
                .HasColumnType("varchar(14)")
                .IsRequired();

            //Criação do relacionamento 1 para 1
            //Fornecedor tem um endereço
            builder.HasOne(p => p.Endereco)
                .WithOne(e => e.Fornecedor);

            //Criação do relacionamento 1 para N
            //Fornecedor tem muitos produtos
            builder.HasMany(p => p.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);
        }
    }
}
