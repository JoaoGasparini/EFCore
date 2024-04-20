namespace Core.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime Criado { get; set; }
    public DateTime? Atualizar { get; set; }
}
