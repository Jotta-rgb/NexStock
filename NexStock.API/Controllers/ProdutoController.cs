using Microsoft.AspNetCore.Mvc;

using NexStock.Application.DTOs;

using NexStock.Application.Services;

namespace NexStock.API.Controllers;

/// <summary>

/// Controller CRUD completo para Produtos.

/// </summary>

[ApiController]

[Route("api/[controller]")]

public class ProdutoController : ControllerBase

{

	private readonly ProdutoService _produtoService;

	public ProdutoController(ProdutoService produtoService)

	{

		_produtoService = produtoService;

	}

	[HttpGet]

	public async Task<IActionResult> ListarTodos()

	{

		var produtos = await _produtoService.ListarTodosAsync();

		return Ok(produtos);

	}

	[HttpGet("{id}")]

	public async Task<IActionResult> ObterPorId(int id)

	{

		var produto = await _produtoService.ObterPorIdAsync(id);

		if (produto == null)

			return NotFound(new { mensagem = $"Produto {id} não encontrado." });

		return Ok(produto);

	}

	[HttpPost]

	public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)

	{

		try

		{

			var produto = await _produtoService.CriarAsync(dto);

			return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);

		}

		catch (InvalidOperationException ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

	}

	[HttpPut("{id}")]

	public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarProdutoDto dto)

	{

		try

		{

			await _produtoService.AtualizarAsync(id, dto);

			return NoContent();

		}

		catch (KeyNotFoundException ex)

		{

			return NotFound(new { mensagem = ex.Message });

		}

		catch (InvalidOperationException ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Remover(int id)
	{
		try
		{
			await _produtoService.RemoverAsync(id);
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
