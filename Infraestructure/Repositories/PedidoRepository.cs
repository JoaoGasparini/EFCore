using Core.Entities;
using Core.Repository;
using Infraestructure.Context;

namespace Infraestructure.Repositories;

public class PedidoRepository : EFRepository<Pedidos>, IPedidoRepository
{
    public PedidoRepository(ApplicationDbContext context) : base(context)
    {
    }
}
