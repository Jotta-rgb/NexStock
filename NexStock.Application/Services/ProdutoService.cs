using NexStock.Application.DTOs;
using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class ProdutoService

{

	private readonly IProdutoRepository _produtoRepository;

	public ProdutoService(IProdutoRepository produtoRepository)

	{

		_produtoRepository = produtoRepository;

	}

	public async Task<IEnumerable<ProdutoDto>> ListarTodosAsync()

	{

		var produtos = await _produtoRepository.ListarTodosAsync();

		return produtos

			.Where(p => p != null)

			.Select(p => new ProdutoDto

			{

				Id = p!.Id,

				Nome = p.Nome,

				Unidade = p.Unidade,

				Quantidade = p.Quantidade,

				EstoqueMinimo = p.EstoqueMinimo,

				CategoriaId = p.CategoriaId,

				LocalizacaoId = p.LocalizacaoId

			});

	}

	public async Task<ProdutoDto?> ObterPorIdAsync(int id)

	{

		var produto = await _produtoRepository.ObterPorIdAsync(id);

		if (produto == null) return null;

		return new ProdutoDto

		{

			Id = produto.Id,

			Nome = produto.Nome,

			Unidade = produto.Unidade,

			Quantidade = produto.Quantidade,

			EstoqueMinimo = produto.EstoqueMinimo,

			CategoriaId = produto.CategoriaId,

			LocalizacaoId = produto.LocalizacaoId

		};

	}

	public async Task<ProdutoDto> CriarAsync(CriarProdutoDto dto)

	{

		if (dto.Quantidade < 0)

			throw new InvalidOperationException("A quantidade do produto não pode ser negativa.");

		if (dto.EstoqueMinimo < 0)

			throw new InvalidOperationException("O estoque mínimo não pode ser negativo.");

		var produto = new Produto

		{

			Nome = dto.Nome,

			Unidade = dto.Unidade,

			Quantidade = dto.Quantidade,

			EstoqueMinimo = dto.EstoqueMinimo,

			CategoriaId = dto.CategoriaId,

			LocalizacaoId = dto.LocalizacaoId

		};

		await _produtoRepository.AdicionarAsync(produto);

		return new ProdutoDto

		{

			Id = produto.Id,

			Nome = produto.Nome,

			Unidade = produto.Unidade,

			Quantidade = produto.Quantidade,

			EstoqueMinimo = produto.EstoqueMinimo,

			CategoriaId = produto.CategoriaId,

			LocalizacaoId = produto.LocalizacaoId

		};

	}

	public async Task AtualizarAsync(int id, AtualizarProdutoDto dto)

	{

		var produto = await _produtoRepository.ObterPorIdAsync(id);

		if (produto == null)

			throw new KeyNotFoundException($"Produto com Id {id} não encontrado.");

		if (dto.Quantidade < 0)

			throw new InvalidOperationException("A quantidade do produto não pode ser negativa.");

		if (dto.EstoqueMinimo < 0)

			throw new InvalidOperationException("O estoque mínimo não pode ser negativo.");

		produto.Nome = dto.Nome;

		produto.Unidade = dto.Unidade;

		produto.Quantidade = dto.Quantidade;

		produto.EstoqueMinimo = dto.EstoqueMinimo;

		produto.CategoriaId = dto.CategoriaId;

		produto.LocalizacaoId = dto.LocalizacaoId;

		await _produtoRepository.AtualizarAsync(produto);

	}

	public async Task RemoverAsync(int id)

	{

		var produto = await _produtoRepository.ObterPorIdAsync(id);

		if (produto == null)

			throw new KeyNotFoundException($"Produto com Id {id} não encontrado.");

		await _produtoRepository.RemoverAsync(id);

	}

}

