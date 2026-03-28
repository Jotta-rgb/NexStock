using NexStock.Application.DTOs;
using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class CategoriaService

{

	private readonly ICategoriaRepository _categoriaRepository;

	public CategoriaService(ICategoriaRepository categoriaRepository)

	{

		_categoriaRepository = categoriaRepository;

	}

	public async Task<IEnumerable<CategoriaDto>> ListarTodosAsync()

	{

		var categorias = await _categoriaRepository.ListarTodosAsync();

		return categorias

			.Where(c => c != null)

			.Select(c => new CategoriaDto

			{

				Id = c!.Id,

				Nome = c.Nome

			});

	}

	public async Task<CategoriaDto?> ObterPorIdAsync(int id)

	{

		var categoria = await _categoriaRepository.ObterPorIdAsync(id);

		if (categoria == null) return null;

		return new CategoriaDto

		{

			Id = categoria.Id,

			Nome = categoria.Nome

		};

	}

	public async Task<CategoriaDto> CriarAsync(CriarCategoriaDto dto)

	{

		var categoria = new Categoria

		{

			Nome = dto.Nome

		};

		await _categoriaRepository.AdicionarAsync(categoria);

		return new CategoriaDto

		{

			Id = categoria.Id,

			Nome = categoria.Nome

		};

	}

	public async Task AtualizarAsync(int id, AtualizarCategoriaDto dto)

	{

		var categoria = await _categoriaRepository.ObterPorIdAsync(id);

		if (categoria == null)

			throw new KeyNotFoundException($"Categoria com Id {id} não encontrada.");

		categoria.Nome = dto.Nome;

		await _categoriaRepository.AtualizarAsync(categoria);

	}

	public async Task RemoverAsync(int id)

	{

		var categoria = await _categoriaRepository.ObterPorIdAsync(id);

		if (categoria == null)

			throw new KeyNotFoundException($"Categoria com Id {id} não encontrada.");

		await _categoriaRepository.RemoverAsync(id);

	}

}

