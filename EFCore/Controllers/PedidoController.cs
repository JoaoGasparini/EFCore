using Core.Entities;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] PedidoInput pedidoInput)
        {
            try
            {
                var pedido = new Pedidos()
                {
                    ClienteId = pedidoInput.ClienteId,
                    LivroId = pedidoInput.LivroId,
                };

                await _pedidoRepository.Cadastrar(pedido);

                return Ok("Pedido cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _pedidoRepository.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
