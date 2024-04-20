using Core.Entities;
using Core.Repository;
using Infraestructure.Context;

namespace Infraestructure.Repositories;

public class LivroRepository : EFRepository<Livro>, ILivroRepository
{
    public LivroRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CadastrarEmMassa(IEnumerable<Livro> livros)
    {
        var tempo1 = System.Diagnostics.Stopwatch.StartNew();

        await _context.AddRangeAsync(livros);
        _context.SaveChanges();

        tempo1.Stop();
        var milisegunds1 = tempo1.ElapsedMilliseconds;

        var tempo2 = System.Diagnostics.Stopwatch.StartNew();

        await _context.BulkInsertAsync(livros);
        
        tempo2.Stop();
        var milisegunds2 = tempo1.ElapsedMilliseconds;

        System.Diagnostics.Debug.WriteLine($"addrange: { milisegunds1 }");
        System.Diagnostics.Debug.WriteLine($"bulkadd: { milisegunds2 }");
    }
}
