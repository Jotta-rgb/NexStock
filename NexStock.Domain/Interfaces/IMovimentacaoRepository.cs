using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface IMovimentacaoRepository
{
	Task<Movimentacao?> ObterPorIdAsync(int id);
	Task<IEnumerable<Movimentacao?>> ListarTodosAsync();
	Task AdicionarAsync(Movimentacao movimentacao);
	Task AtualizarAsync(Movimentacao movimentacao);
	Task RemoverAsync(int id);
}
