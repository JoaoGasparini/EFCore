namespace Core.Entities;

public class Cliente : EntityBase
{
    public required string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public required string CPF { get; set; }

    public virtual ICollection<Pedidos> Pedidos { get; set; }
}

