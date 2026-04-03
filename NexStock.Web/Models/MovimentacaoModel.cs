namespace NexStock.Web.Models
{
	public class MovimentacaoModel
	{
		public int Id { get; set; }
		public string Tipo { get; set; } = string.Empty;
		public string Produto { get; set; } = "";
		public int Quantidade { get; set; }
		public string Responsavel { get; set; } = string.Empty;
		public string? NotaFiscal { get; set; }
		public DateTime Data { get; set; }
		public int ProdutoId { get; set; }
		public int UsuarioId { get; set; }
	}
}
