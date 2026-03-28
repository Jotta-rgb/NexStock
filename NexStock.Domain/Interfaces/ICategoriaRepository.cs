using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface ICategoriaRepository
{
	Task<Categoria?> ObterPorIdAsync(int id);
	Task<IEnumerable<Categoria?>> ListarTodosAsync();
	Task AdicionarAsync(Categoria categoria);
	Task AtualizarAsync(Categoria categoria);
	Task RemoverAsync(int id);
}
