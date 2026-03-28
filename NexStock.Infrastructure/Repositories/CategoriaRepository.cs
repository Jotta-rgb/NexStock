using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CategoriaRepository : ICategoriaRepository

{

	private readonly NexStockDbContext _context;

	public CategoriaRepository(NexStockDbContext context)

	{

		_context = context;

	}

	public async Task<Categoria?> ObterPorIdAsync(int id)

		=> await _context.Categorias.FindAsync(id);

	public async Task<IEnumerable<Categoria>> ListarTodosAsync()

		=> await _context.Categorias.ToListAsync();

	public async Task AdicionarAsync(Categoria categoria)

	{

		await _context.Categorias.AddAsync(categoria);

		await _context.SaveChangesAsync();

	}

	public async Task AtualizarAsync(Categoria categoria)

	{

		_context.Categorias.Update(categoria);

		await _context.SaveChangesAsync();

	}

	public async Task RemoverAsync(int id)

	{

		var categoria = await ObterPorIdAsync(id);

		if (categoria != null)

		{

			_context.Categorias.Remove(categoria);

			await _context.SaveChangesAsync();

		}

	}

}
