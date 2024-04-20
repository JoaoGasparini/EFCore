using Core.Entities;

namespace Core.Repository;

public interface ILivroRepository : IRepository<Livro>
{
    Task CadastrarEmMassa(IEnumerable<Livro> livros);
}
