namespace Core.Entities;

public class Pedidos : EntityBase
{
    public int ClienteId { get; set; }
    public int LivroId { get; set; }

    public virtual Cliente Cliente { get; set; }
    public virtual Livro Livro { get; set; }
}
