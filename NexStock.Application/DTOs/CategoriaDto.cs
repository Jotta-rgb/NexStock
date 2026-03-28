namespace NexStock.Application.DTOs;

public class CategoriaDto
{
	public int Id { get; set; }
	public string Nome { get; set; } = string.Empty;
}
public class CriarCategoriaDto
{
	public string Nome { get; set; } = string.Empty;
}
public class AtualizarCategoriaDto
{
	public string Nome { get; set; } = string.Empty;
}
