using Microsoft.AspNetCore.Mvc;
using NexStock.Application.DTOs;
using NexStock.Application.Services;
namespace NexStock.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
	private readonly CategoriaService _categoriaService;

	public CategoriaController(CategoriaService categoriaService)
	{
		_categoriaService = categoriaService;
	}
	[HttpGet]
	public async Task<IActionResult> GetCategorias()
	{
		var categorias = await _categoriaService.ListarTodosAsync();
		return Ok(categorias);
	}
	[HttpGet("{id}")]
	public async Task<IActionResult> GetCategoriaPorId(int id)
	{
		var categoria = await _categoriaService.ObterPorIdAsync(id);

		if (categoria == null) return NotFound(new { mensagem = "Categoria não encontrada." });

		return Ok(categoria);
	}
	[HttpPost]
	public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaDto dto)
	{
		if (dto == null || string.IsNullOrWhiteSpace(dto.Nome)) return BadRequest(new { mensagem = "O nome da categoria é obrigatório." });

		var categoria = await _categoriaService.CriarAsync(dto);

		return CreatedAtAction(nameof(GetCategoriaPorId), new { id = categoria.Id }, categoria);
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] AtualizarCategoriaDto dto)
	{
		if (dto == null || string.IsNullOrWhiteSpace(dto.Nome)) return BadRequest(new { mensagem = "O nome da categoria é obrigatório." });

		try
		{
			await _categoriaService.AtualizarAsync(id, dto);
			return NoContent();
		}
		catch (KeyNotFoundException ex)
		{
			return NotFound(new { mensagem = ex.Message });
		}
	}
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletarCategoria(int id)
	{
		try
		{
			await _categoriaService.RemoverAsync(id);
			return NoContent();
		}
		catch (KeyNotFoundException ex)
		{
			return NotFound(new { mensagem = ex.Message });
		}
		catch (Exception ex)
		{
			return BadRequest(new { mensagem = ex.Message });
		}
	}



}
