namespace NexStock.Domain.Entities;

public class Movimentacao
{
	public int Id { get; set; }

	public string Tipo { get; set; } = string.Empty;

	public int Quantidade { get; set; }

	public string Responsavel { get; set; } = string.Empty;

	public string? NotaFiscal { get; set; }

	public DateTime Data { get; set; }

	public int ProdutoId { get; set; }

	public Produto Produto { get; set; } = null!;

	public int UsuarioId { get; set; }

	public Usuario Usuario { get; set; } = null!;

}
