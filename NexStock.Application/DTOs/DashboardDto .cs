namespace NexStock.Application.DTOs;

public class DashboardDto
{
	public int TotalProdutos { get; set; }

	public int TotalProdutosEstoqueMinimo { get; set; }

	public int TotalProdutosSemEstoque { get; set; }

	public List<ProdutoDto> ProdutosEstoqueMinimo { get; set; } = new();

	public List<ProdutoDto> ProdutosMaisSaida { get; set; } = new();
}

