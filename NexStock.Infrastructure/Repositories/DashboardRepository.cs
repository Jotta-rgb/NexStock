using NexStock.Domain.Entities;
using NexStock.Domain.Interfaces;
using NexStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace NexStock.Infrastructure.Repositories;

public class DashboardRepository : IDashboardRepository
{
	private readonly NexStockDbContext _context;

	public DashboardRepository(NexStockDbContext context)
	{
		_context = context;
	}

	public async Task<Dashboard?> ObterResumoAsync()
	{
		var totalProdutos = await _context.Produtos.CountAsync();

		var produtosEstoqueMinimo = await _context.Produtos
			.Where(p => p.Quantidade <= p.EstoqueMinimo)
			.ToListAsync();

		var totalProdutosEstoqueMinimo = produtosEstoqueMinimo.Count;

		var totalProdutosSemEstoque = await _context.Produtos
			.CountAsync(p => p.Quantidade == 0);

		var produtosMaisSaidaIds = await _context.Movimentacoes
			.Where(m => m.Tipo.ToLower() == "saida")
			.GroupBy(m => m.ProdutoId)
			.OrderByDescending(g => g.Count())
			.Select(g => g.Key)
			.ToListAsync();

		var produtosMaisSaida = await _context.Produtos
			.Where(p => produtosMaisSaidaIds.Contains(p.Id))
			.ToListAsync();

		produtosMaisSaida = produtosMaisSaida
			.OrderBy(p => produtosMaisSaidaIds.IndexOf(p.Id))
			.ToList();

		var dashboard = new Dashboard
		{
			TotalProdutos = totalProdutos,
			TotalProdutosEstoqueMinimo = totalProdutosEstoqueMinimo,
			TotalProdutosSemEstoque = totalProdutosSemEstoque,
			ProdutosEstoqueMinimo = produtosEstoqueMinimo,
			ProdutosMaisSaida = produtosMaisSaida
		};

		return dashboard;
	}
}


