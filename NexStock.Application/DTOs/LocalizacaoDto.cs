namespace NexStock.Application.DTOs;

public class LocalizacaoDto
{
	public int Id { get; set; }
	public string Nome { get; set; } = string.Empty;
}
public class CriarLocalizacaoDto
{
	public string Nome { get; set; } = string.Empty;
}
public class AtualizarLocalizacaoDto
{
	public string Nome { get; set; } = string.Empty;
}