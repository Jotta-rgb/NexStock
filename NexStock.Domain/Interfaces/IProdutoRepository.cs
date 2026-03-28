using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface IProdutoRepository
{
	Task<Produto?> ObterPorIdAsync(int id);
	Task<IEnumerable<Produto?>> ListarTodosAsync();
	Task AdicionarAsync(Produto produto);
	Task AtualizarAsync(Produto produto);
	Task RemoverAsync(int id);
}
