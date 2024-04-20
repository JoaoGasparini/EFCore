using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repositories.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();// TIRA A PROPRIEDADE DE IDENTITY DO SQL E QUEM DEFINE É O ORM

        builder.Property(p => p.Criado)
                .HasColumnName("Criado")
                .HasColumnType("DATETIME")
                .IsRequired();

        builder.Property(p => p.Atualizar)
        .HasColumnName("Atualizar")
        .HasColumnType("DATETIME");

        builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

        builder.Property(p => p.DataNascimento)
                .HasColumnName("Data_Nascimento")
                .HasColumnType("VARCHAR(100)");

        builder.Property(p => p.CPF)
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR(11)")
                .IsRequired();
    }
}
