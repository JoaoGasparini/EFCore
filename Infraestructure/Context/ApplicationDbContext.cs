using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Context;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext()
    {
        IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        _connectionString = configuration.GetConnectionString("ConnectionString");
    }

    //public ApplicationDbContext()
    //{

    //}

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedidos> Pedidos { get; set; }
    public DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ClienteConfiguration()); //MANEIRA SEPARADA
        //modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        //modelBuilder.ApplyConfiguration(new LivroConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); //MANEIRA COMPLETA
    }
}