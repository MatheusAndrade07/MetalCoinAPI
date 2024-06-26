using Metalcoin.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetalCoin.Infra.Data.Mappings
{
    internal class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Logradouro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Numero).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.Complemento).HasColumnType("varchar(100)");
            builder.Property(p => p.Cep).IsRequired().HasColumnType("varchar(8)");
            builder.Property(p => p.Bairro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Cidade).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Estado).IsRequired().HasColumnType("varchar(2)");
        }
    }
}
