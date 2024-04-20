namespace Core.Models;

public class PedidoDto
{
    public int Id { get; set; }
    public DateTime Criado { get; set; }
    public DateTime? Atualizar { get; set; }
    public int ClienteId { get; set; }
    public int LivroId { get; set; }

    public virtual ClienteInput Cliente { get; set; }
    public virtual LivroDto Livro { get; set; }
}
