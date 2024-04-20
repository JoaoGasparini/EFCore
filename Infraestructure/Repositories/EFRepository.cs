using Core.Entities;
using Core.Repository;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class EFRepository<T> : IRepository<T> where T : EntityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbset;

    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbset = context.Set<T>();
    }

    public async Task Alterar(T entidade)
    {
        entidade.Atualizar = DateTime.Now;
        _dbset.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task Cadastrar(T entidade)
    {
        entidade.Criado = DateTime.Now;

        _dbset.Add(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        _dbset.Remove(await ObterPorId(id));
        await _context.SaveChangesAsync();
    }

    public async Task<T> ObterPorId(int id)
        => await _dbset.FirstOrDefaultAsync(entity => entity.Id == id);


    public async Task<IList<T>> ObterTodos()
    {
        return await _dbset.ToListAsync();
    }
}
