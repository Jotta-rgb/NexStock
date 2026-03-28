using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace NexStock.Infrastructure.Repositories;

public class LocalizacaoRepository : ILocalizacaoRepository

{

	private readonly NexStockDbContext _context;

	public LocalizacaoRepository(NexStockDbContext context)

	{

		_context = context;

	}

	public async Task<Localizacao?> ObterPorIdAsync(int id)

		=> await _context.Localizacoes.FindAsync(id);

	public async Task<IEnumerable<Localizacao>> ListarTodosAsync()

		=> await _context.Localizacoes.ToListAsync();

	public async Task AdicionarAsync(Localizacao localizacao)

	{

		await _context.Localizacoes.AddAsync(localizacao);

		await _context.SaveChangesAsync();

	}

	public async Task AtualizarAsync(Localizacao localizacao)

	{

		_context.Localizacoes.Update(localizacao);

		await _context.SaveChangesAsync();

	}

	public async Task RemoverAsync(int id)

	{

		var localizacao = await ObterPorIdAsync(id);

		if (localizacao != null)

		{

			_context.Localizacoes.Remove(localizacao);

			await _context.SaveChangesAsync();

		}

	}

}
