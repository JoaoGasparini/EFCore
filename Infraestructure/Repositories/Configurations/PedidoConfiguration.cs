using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repositories.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedidos>
{
    public void Configure(EntityTypeBuilder<Pedidos> builder)
    {
        builder.ToTable("Pedido");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

        builder.Property(p => p.Criado)
                .HasColumnName("Criado")
                .HasColumnType("DATETIME")
                .IsRequired();

        builder.Property(p => p.Atualizar)
        .HasColumnName("Atualizar")
        .HasColumnType("DATETIME");

        builder.Property(p => p.ClienteId)
                .HasColumnType("INT")
                .IsRequired();

        builder.Property(p => p.LivroId)
                .HasColumnType("INT")
                .IsRequired();

        builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasPrincipalKey(c => c.Id); // EXISTE UM CLIENTE COM VARIOS PEDIDOS E A PRINCIPAL CHAVE É O ID DE CLIENTE

        builder.HasOne(p => p.Livro)
                .WithMany(c => c.Pedidos)
                .HasPrincipalKey(c => c.Id); // EXISTE UM LIVRO EM VARIOS PEDIDOS E A PRINCIPAL CHAVE É O ID DE CLIENTE
    }
}
