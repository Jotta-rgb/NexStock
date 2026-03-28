using System;
using System.Collections.Generic;
using System.Text;

namespace NexStock.Domain.Entities;

public class Produto
{
	public int Id { get; set; }

	public string Nome { get; set; } = string.Empty;

	public string Unidade { get; set; } = string.Empty;

	public int Quantidade { get; set; }

	public int EstoqueMinimo { get; set; }

	public int CategoriaId { get; set; }

	public Categoria? Categoria { get; set; }

	public int LocalizacaoId { get; set; }

	public Localizacao? Localizacao { get; set; }

	public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();

}
