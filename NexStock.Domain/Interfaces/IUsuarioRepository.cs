using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface IUsuarioRepository
{
	Task<Usuario?> ObterPorIdAsync(int id);

	Task<Usuario?> ObterPorEmailAsync(string email);

	Task<IEnumerable<Usuario?>> ListarTodosAsync();

	Task AdicionarAsync(Usuario usuario);

	Task AtualizarAsync(Usuario usuario);

	Task RemoverAsync(int id);

}
