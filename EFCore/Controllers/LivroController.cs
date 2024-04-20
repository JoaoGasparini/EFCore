using Core.Entities;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostLivro([FromBody] LivroInput livroInput)
        {
            try
            {
                var livro = new Livro() 
                { 
                    Nome = livroInput.Nome,
                    Editora = livroInput.Editora,
                };

                await _livroRepository.Cadastrar(livro);

                return Ok();
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
                var livrosDto = new List<LivroDto>();
                var livros = await _livroRepository.ObterTodos();

                foreach (var livro in livros)
                {
                    livrosDto.Add(new LivroDto()
                    {
                        Nome = livro.Nome,
                        Criado = DateTime.Now,
                        Pedidos = livro.Pedidos,
                        Id = livro.Id,
                        Editora = livro.Editora
                    });
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await _livroRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(LivroUpdateInput livroInput)
        {
            try
            {
                var livroDB = await _livroRepository.ObterPorId(livroInput.Id);
                livroDB.Editora = livroInput.Editora;
                livroDB.Nome = livroInput.Nome;

                await _livroRepository.Alterar(livroDB);

                return Ok($"Livro de Id: {livroDB.Id} atualizado.");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _livroRepository.Deletar(id);
                return Ok($"Objeto de Id: {id} deletado.");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("cadastro-em-massa")]
        public async Task<IActionResult> CadastroEmMassa()
        {
            try
            {
                var livros = new List<Livro>()
                {
                    new Livro() { Nome = "Livro 1", Editora = "Editora" },
                    new Livro() { Nome = "Livro 2", Editora = "Editora" },
                    new Livro() { Nome = "Livro 3", Editora = "Editora" },
                    new Livro() { Nome = "Livro 4", Editora = "Editora" },
                    new Livro() { Nome = "Livro 5", Editora = "Editora" },
                    new Livro() { Nome = "Livro 6", Editora = "Editora" },
                    new Livro() { Nome = "Livro 7", Editora = "Editora" },
                    new Livro() { Nome = "Livro 8", Editora = "Editora" },
                    new Livro() { Nome = "Livro 9", Editora = "Editora" },
                    new Livro() { Nome = "Livro 10", Editora = "Editora" },
                };

                await _livroRepository.CadastrarEmMassa(livros);
                return Ok("Livros cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
