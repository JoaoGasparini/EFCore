using Core.Entities;
using Core.Models;
using Core.Repository;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {


    }

    public async Task<ClienteInput> ObterPedidosSeisMeses(int idCliente)
    {
        var cliente = await _context.Clientes
                        .FirstOrDefaultAsync(c => c.Id == idCliente)
                        ?? throw new Exception("Este cliente não existe.");
        return new ClienteInput()
        {
            Id = cliente.Id,
            Criado = cliente.Criado,
            Nome = cliente.Nome,
            DataDeNascimento = cliente.DataNascimento,
            Pedidos = cliente.Pedidos
            .Where(c => c.Criado >= DateTime.Now.AddMonths(-6))
            .Select(pedido => new PedidoDto()
            {
                Id = pedido.Id,
                Criado = pedido.Criado,
                LivroId = pedido.LivroId,
                ClienteId = pedido.ClienteId,
                Livro = new LivroDto()
                {
                    Id = pedido.Livro.Id,
                    Criado = pedido.Livro.Criado,
                    Nome = pedido.Livro.Nome,
                    Editora = pedido.Livro.Editora
                }
            }).ToList()
        };
    }
}
