namespace NexStock.Web.Models
{
	public class ProdutoModel
	{
		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Unidade { get; set; } = string.Empty;
		public int Quantidade { get; set; }
		public int EstoqueMinimo { get; set; }
		public int CategoriaId { get; set; }
		public int LocalizacaoId { get; set; }
	}
}
