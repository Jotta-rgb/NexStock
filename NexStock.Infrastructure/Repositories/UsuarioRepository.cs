using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace NexStock.Infrastructure.Repositories;


public class UsuarioRepository : IUsuarioRepository
{
	private readonly NexStockDbContext _context;

	public UsuarioRepository(NexStockDbContext context)

	{

		_context = context;

	}

	public async Task<Usuario?> ObterPorIdAsync(int id)

		=> await _context.Usuarios.FindAsync(id);

	public async Task<Usuario?> ObterPorEmailAsync(string email)

		=> await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

	public async Task<IEnumerable<Usuario>> ListarTodosAsync()

		=> await _context.Usuarios.ToListAsync();

	public async Task AdicionarAsync(Usuario usuario)

	{

		await _context.Usuarios.AddAsync(usuario);

		await _context.SaveChangesAsync();

	}

	public async Task AtualizarAsync(Usuario usuario)

	{

		_context.Usuarios.Update(usuario);

		await _context.SaveChangesAsync();

	}

	public async Task RemoverAsync(int id)

	{

		var usuario = await ObterPorIdAsync(id);

		if (usuario != null)

		{

			_context.Usuarios.Remove(usuario);

			await _context.SaveChangesAsync();

		}

	}

}
