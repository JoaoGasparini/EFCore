using Core.Entities;

namespace Core.Models;

public class ClienteInput
{
    public DateTime Criado { get; set; }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime? DataDeNascimento { get; set; }
    public ICollection<PedidoDto> Pedidos { get; set; }
}
