using Core.Entities;

namespace Core.Models;

public class LivroDto
{
    public int Id { get; set; }

    public DateTime Criado { get; set; }

    public required string Nome { get; set; }

    public required string Editora { get; set; }

    public ICollection<Pedidos> Pedidos { get; set; }
}
