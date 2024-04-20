namespace Core.Entities;

public class Livro : EntityBase
{
    public Livro()
    {
        Criado = DateTime.Now;   
    }

    public required string Nome { get; set; }
    public required string Editora { get; set; }

    public virtual ICollection<Pedidos> Pedidos { get; set; }
}
