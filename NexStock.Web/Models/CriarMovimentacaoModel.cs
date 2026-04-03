namespace NexStock.Web.Models
{
	public class CriarMovimentacaoModel
	{
		public string Tipo { get; set; } = string.Empty;
		public int Quantidade { get; set; }
		public string Responsavel { get; set; } = string.Empty;
		public string? NotaFiscal { get; set; }
		public int ProdutoId { get; set; }
		public int UsuarioId { get; set; }
	}
}

