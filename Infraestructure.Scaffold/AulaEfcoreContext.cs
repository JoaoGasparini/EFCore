using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Scaffold;

public partial class AulaEfcoreContext : DbContext
{
    public AulaEfcoreContext()
    {
    }

    public AulaEfcoreContext(DbContextOptions<AulaEfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AULA_EFCORE;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CPF");
            entity.Property(e => e.Criado).HasColumnType("datetime");
            entity.Property(e => e.DataNascimento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Data_Nascimento");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.ToTable("Livro");

            entity.Property(e => e.Criado).HasColumnType("datetime");
            entity.Property(e => e.Editora)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Pedido");

            entity.HasIndex(e => e.ClienteId, "IX_Pedido_ClienteId");

            entity.HasIndex(e => e.LivroId, "IX_Pedido_LivroId");

            entity.Property(e => e.Criado).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.Livro).WithMany(p => p.Pedidos).HasForeignKey(d => d.LivroId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
