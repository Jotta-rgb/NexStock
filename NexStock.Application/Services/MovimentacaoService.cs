using NexStock.Application.DTOs;
using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class MovimentacaoService
{
	private readonly IMovimentacaoRepository _movimentacaoRepository;
	private readonly IProdutoRepository _produtoRepository;
	public MovimentacaoService(
		IMovimentacaoRepository movimentacaoRepository,
		IProdutoRepository produtoRepository)
	{
		_movimentacaoRepository = movimentacaoRepository;
		_produtoRepository = produtoRepository;
	}
	public async Task<IEnumerable<MovimentacaoDto>> ListarTodosAsync()
	{
		var movimentacoes = await _movimentacaoRepository.ListarTodosAsync();
		return movimentacoes
			.Where(m => m != null)
			.Select(m => new MovimentacaoDto
			{
				Id = m!.Id,
				Tipo = m.Tipo,
				Quantidade = m.Quantidade,
				Responsavel = m.Responsavel,
				NotaFiscal = m.NotaFiscal,
				Data = m.Data,
				ProdutoId = m.ProdutoId,
				UsuarioId = m.UsuarioId
			});
	}
	public async Task<MovimentacaoDto?> ObterPorIdAsync(int id)
	{
		var movimentacao = await _movimentacaoRepository.ObterPorIdAsync(id);
		if (movimentacao == null)
			return null;
		return new MovimentacaoDto
		{
			Id = movimentacao.Id,
			Tipo = movimentacao.Tipo,
			Quantidade = movimentacao.Quantidade,
			Responsavel = movimentacao.Responsavel,
			NotaFiscal = movimentacao.NotaFiscal,
			Data = movimentacao.Data,
			ProdutoId = movimentacao.ProdutoId,
			UsuarioId = movimentacao.UsuarioId
		};
	}
	public async Task<MovimentacaoDto> CriarAsync(CriarMovimentacaoDto dto)
	{
		var produto = await _produtoRepository.ObterPorIdAsync(dto.ProdutoId);
		if (produto == null)
			throw new KeyNotFoundException($"Produto com Id {dto.ProdutoId} não encontrado.");
		if (dto.Quantidade <= 0)
			throw new InvalidOperationException("A quantidade da movimentação deve ser maior que zero.");
		var tipo = dto.Tipo.Trim().ToLower();
		if (tipo != "entrada" && tipo != "saida")
			throw new InvalidOperationException("Tipo de movimentação inválido. Use 'entrada' ou 'saida'.");
		if (tipo == "saida" && produto.Quantidade < dto.Quantidade)
			throw new InvalidOperationException("Estoque insuficiente para realizar a saída.");
		if (tipo == "entrada")
			produto.Quantidade += dto.Quantidade;
		else
			produto.Quantidade -= dto.Quantidade;
		await _produtoRepository.AtualizarAsync(produto);
		var movimentacao = new Movimentacao
		{
			Tipo = dto.Tipo,
			Quantidade = dto.Quantidade,
			Responsavel = dto.Responsavel,
			NotaFiscal = dto.NotaFiscal,
			Data = DateTime.Now,
			ProdutoId = dto.ProdutoId,
			UsuarioId = dto.UsuarioId
		};
		await _movimentacaoRepository.AdicionarAsync(movimentacao);
		return new MovimentacaoDto
		{
			Id = movimentacao.Id,
			Tipo = movimentacao.Tipo,
			Quantidade = movimentacao.Quantidade,
			Responsavel = movimentacao.Responsavel,
			NotaFiscal = movimentacao.NotaFiscal,
			Data = movimentacao.Data,
			ProdutoId = movimentacao.ProdutoId,
			UsuarioId = movimentacao.UsuarioId
		};
	}
	public async Task AtualizarAsync(int id, AtualizarMovimentacaoDto dto)
	{
		var movimentacao = await _movimentacaoRepository.ObterPorIdAsync(id);
		if (movimentacao == null)
			throw new KeyNotFoundException($"Movimentação com Id {id} não encontrada.");
		if (dto.Quantidade <= 0)
			throw new InvalidOperationException("A quantidade da movimentação deve ser maior que zero.");
		var tipo = dto.Tipo.Trim().ToLower();
		if (tipo != "entrada" && tipo != "saida")
			throw new InvalidOperationException("Tipo de movimentação inválido. Use 'entrada' ou 'saida'.");
		movimentacao.Tipo = dto.Tipo;
		movimentacao.Quantidade = dto.Quantidade;
		movimentacao.Responsavel = dto.Responsavel;
		movimentacao.NotaFiscal = dto.NotaFiscal;
		movimentacao.ProdutoId = dto.ProdutoId;
		movimentacao.UsuarioId = dto.UsuarioId;
		await _movimentacaoRepository.AtualizarAsync(movimentacao);
	}
	public async Task RemoverAsync(int id)
	{
		var movimentacao = await _movimentacaoRepository.ObterPorIdAsync(id);
		if (movimentacao == null)
			throw new KeyNotFoundException($"Movimentação com Id {id} não encontrada.");
		await _movimentacaoRepository.RemoverAsync(id);
	}
}