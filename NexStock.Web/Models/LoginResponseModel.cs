namespace NexStock.Web.Models
{
	public class LoginResponseModel
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public bool Sucesso { get; set; }
		public string Mensagem { get; set; } = string.Empty;
	}
}
