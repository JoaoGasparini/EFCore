using Core.Entities;

namespace Core.Repository;

public interface IRepository <T> where T : EntityBase
{
    Task<IList<T>> ObterTodos();
    Task<T> ObterPorId(int id);
    Task Cadastrar(T entidade);
    Task Alterar(T entidade);
    Task Deletar(int id);
}
