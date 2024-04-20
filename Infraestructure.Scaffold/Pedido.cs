using System;
using System.Collections.Generic;

namespace Infraestructure.Scaffold;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int LivroId { get; set; }

    public DateTime Criado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Livro Livro { get; set; } = null!;
}
