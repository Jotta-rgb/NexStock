using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace NexStock.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
	private readonly NexStockDbContext _context;

	public ProdutoRepository(NexStockDbContext context)

	{

		_context = context;

	}

	public async Task<Produto?> ObterPorIdAsync(int id)

		=> await _context.Produtos.FindAsync(id);

	public async Task<IEnumerable<Produto>> ListarTodosAsync()

		=> await _context.Produtos.ToListAsync();

	public async Task AdicionarAsync(Produto produto)

	{

		await _context.Produtos.AddAsync(produto);

		await _context.SaveChangesAsync();

	}

	public async Task AtualizarAsync(Produto produto)

	{

		_context.Produtos.Update(produto);

		await _context.SaveChangesAsync();

	}

	public async Task RemoverAsync(int id)
	{
		var produto = await ObterPorIdAsync(id);

		if (produto == null)
			return;

		try
		{
			_context.Produtos.Remove(produto);
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateException)
		{
			throw new Exception("Não é possível excluir este produto, pois existem movimentações vinculadas a ele.");
		}
	}



}
