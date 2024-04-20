using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repositories.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livro");
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

        builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

        builder.Property(p => p.Editora)
                .HasColumnName("Editora")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
    }
}
