using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace NexStock.Infrastructure.Repositories;

public class MovimentacaoRepository : IMovimentacaoRepository

{

	private readonly NexStockDbContext _context;

	public MovimentacaoRepository(NexStockDbContext context)

	{

		_context = context;

	}

	public async Task<Movimentacao?> ObterPorIdAsync(int id)

		=> await _context.Movimentacoes.FindAsync(id);

	public async Task<IEnumerable<Movimentacao>> ListarTodosAsync()

		=> await _context.Movimentacoes.ToListAsync();

	public async Task AdicionarAsync(Movimentacao movimentacao)

	{

		await _context.Movimentacoes.AddAsync(movimentacao);

		await _context.SaveChangesAsync();

	}

	public async Task AtualizarAsync(Movimentacao movimentacao)

	{

		_context.Movimentacoes.Update(movimentacao);

		await _context.SaveChangesAsync();

	}

	public async Task RemoverAsync(int id)

	{

		var movimentacao = await ObterPorIdAsync(id);

		if (movimentacao != null)

		{

			_context.Movimentacoes.Remove(movimentacao);

			await _context.SaveChangesAsync();

		}

	}

}
