using NexStock.Application.DTOs;
using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class LocalizacaoService

{

	private readonly ILocalizacaoRepository _localizacaoRepository;

	public LocalizacaoService(ILocalizacaoRepository localizacaoRepository)

	{

		_localizacaoRepository = localizacaoRepository;

	}

	public async Task<IEnumerable<LocalizacaoDto>> ListarTodosAsync()

	{

		var localizacoes = await _localizacaoRepository.ListarTodosAsync();

		return localizacoes

			.Where(l => l != null)

			.Select(l => new LocalizacaoDto

			{

				Id = l!.Id,

				Nome = l.Nome

			});

	}

	public async Task<LocalizacaoDto?> ObterPorIdAsync(int id)

	{

		var localizacao = await _localizacaoRepository.ObterPorIdAsync(id);

		if (localizacao == null) return null;

		return new LocalizacaoDto

		{

			Id = localizacao.Id,

			Nome = localizacao.Nome

		};

	}

	public async Task<LocalizacaoDto> CriarAsync(CriarLocalizacaoDto dto)

	{

		var localizacao = new Localizacao

		{

			Nome = dto.Nome

		};

		await _localizacaoRepository.AdicionarAsync(localizacao);

		return new LocalizacaoDto

		{

			Id = localizacao.Id,

			Nome = localizacao.Nome

		};

	}

	public async Task AtualizarAsync(int id, AtualizarLocalizacaoDto dto)

	{

		var localizacao = await _localizacaoRepository.ObterPorIdAsync(id);

		if (localizacao == null)

			throw new KeyNotFoundException($"Localização com Id {id} não encontrada.");

		localizacao.Nome = dto.Nome;

		await _localizacaoRepository.AtualizarAsync(localizacao);

	}

	public async Task RemoverAsync(int id)

	{

		var localizacao = await _localizacaoRepository.ObterPorIdAsync(id);

		if (localizacao == null)

			throw new KeyNotFoundException($"Localização com Id {id} não encontrada.");

		await _localizacaoRepository.RemoverAsync(id);

	}

}

