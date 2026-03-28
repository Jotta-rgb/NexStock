using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface ILocalizacaoRepository
{
	Task<Localizacao?> ObterPorIdAsync(int id);
	Task<IEnumerable<Localizacao?>> ListarTodosAsync();
	Task AdicionarAsync(Localizacao localizacao);
	Task AtualizarAsync(Localizacao localizacao);
	Task RemoverAsync(int id);
}
