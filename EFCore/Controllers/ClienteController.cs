using Core.Entities;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] ClienteInput clientInput)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Nome = clientInput.Nome,
                    CPF = clientInput.Cpf,
                    DataNascimento = DateTime.Now
                };

                await _clienteRepository.Cadastrar(cliente);

                return Ok("Cliente cadastrado com sucesso.");
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
                return Ok(await _clienteRepository.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("pedidos-seis-meses/{idCliente:int}")]
        public async Task<IActionResult> GetRelatorio([FromRoute] int idCliente)
        {
            try
            {
                return Ok(await _clienteRepository.ObterPedidosSeisMeses(idCliente));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
