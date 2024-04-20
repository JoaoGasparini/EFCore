using System;
using System.Collections.Generic;

namespace Infraestructure.Scaffold;

public partial class Livro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Editora { get; set; } = null!;

    public DateTime Criado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
