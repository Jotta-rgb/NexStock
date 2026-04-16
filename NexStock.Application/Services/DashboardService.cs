using NexStock.Application.DTOs;
using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class DashboardService
{
	private readonly IDashboardRepository _dashboardRepository;

	public DashboardService(IDashboardRepository dashboardRepository)
	{
		_dashboardRepository = dashboardRepository;
	}

	public async Task<DashboardDto?> ObterResumoAsync()
	{
		var dashboard = await _dashboardRepository.ObterResumoAsync();

		if (dashboard == null) return null;

		return new DashboardDto
		{
			TotalProdutos = dashboard.TotalProdutos,
			TotalProdutosEstoqueMinimo = dashboard.TotalProdutosEstoqueMinimo,
			TotalProdutosSemEstoque = dashboard.TotalProdutosSemEstoque,

			ProdutosEstoqueMinimo = dashboard.ProdutosEstoqueMinimo
				.Select(p => new ProdutoDto
				{
					Id = p.Id,
					Nome = p.Nome,
					Unidade = p.Unidade,
					Quantidade = p.Quantidade,
					EstoqueMinimo = p.EstoqueMinimo,
					CategoriaId = p.CategoriaId,
					LocalizacaoId = p.LocalizacaoId
				})
				.ToList(),

			ProdutosMaisSaida = dashboard.ProdutosMaisSaida
				.Select(p => new ProdutoDto
				{
					Id = p.Id,
					Nome = p.Nome,
					Unidade = p.Unidade,
					Quantidade = p.Quantidade,
					EstoqueMinimo = p.EstoqueMinimo,
					CategoriaId = p.CategoriaId,
					LocalizacaoId = p.LocalizacaoId
				})
				.ToList()
		};
	}
}


