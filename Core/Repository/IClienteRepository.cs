using Core.Entities;
using Core.Models;

namespace Core.Repository;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<ClienteInput> ObterPedidosSeisMeses(int idCliente);
}
