using System;
using System.Collections.Generic;
using System.Text;

namespace NexStock.Domain.Entities;

public class Dashboard
{
	public int TotalProdutos { get; set; }

	public int TotalProdutosEstoqueMinimo { get; set; }

	public int TotalProdutosSemEstoque { get; set; }

	public ICollection<Produto> ProdutosEstoqueMinimo { get; set; } = new List<Produto>();

	public ICollection<Produto> ProdutosMaisSaida { get; set; } = new List<Produto>();
}

