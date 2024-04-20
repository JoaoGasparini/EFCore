using System;
using System.Collections.Generic;

namespace Infraestructure.Scaffold;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string DataNascimento { get; set; } = null!;

    public DateTime Criado { get; set; }

    public string Cpf { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
