using Microsoft.AspNetCore.Mvc;

using NexStock.Application.DTOs;

using NexStock.Application.Services;

namespace NexStock.API.Controllers;

[ApiController]

[Route("api/[controller]")]

public class MovimentacaoController : ControllerBase

{

	private readonly MovimentacaoService _movimentacaoService;

	public MovimentacaoController(MovimentacaoService movimentacaoService)

	{

		_movimentacaoService = movimentacaoService;

	}

	[HttpGet]

	public async Task<IActionResult> ListarTodos()

	{

		var movimentacoes = await _movimentacaoService.ListarTodosAsync();

		return Ok(movimentacoes);

	}

	[HttpGet("{id}")]

	public async Task<IActionResult> ObterPorId(int id)

	{

		var movimentacao = await _movimentacaoService.ObterPorIdAsync(id);

		if (movimentacao == null)

			return NotFound(new { mensagem = $"Movimentação {id} não encontrada." });

		return Ok(movimentacao);

	}

	[HttpPost]

	public async Task<IActionResult> Criar([FromBody] CriarMovimentacaoDto dto)

	{

		try

		{

			var movimentacao = await _movimentacaoService.CriarAsync(dto);

			return CreatedAtAction(nameof(ObterPorId), new { id = movimentacao.Id }, movimentacao);

		}

		catch (KeyNotFoundException ex)

		{

			return NotFound(new { mensagem = ex.Message });

		}

		catch (InvalidOperationException ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

		catch (Exception ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

	}

	[HttpPut("{id}")]

	public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarMovimentacaoDto dto)

	{

		try

		{

			await _movimentacaoService.AtualizarAsync(id, dto);

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

		catch (Exception ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

	}

	[HttpDelete("{id}")]

	public async Task<IActionResult> Remover(int id)

	{

		try

		{

			await _movimentacaoService.RemoverAsync(id);

			return NoContent();

		}

		catch (KeyNotFoundException ex)

		{

			return NotFound(new { mensagem = ex.Message });

		}

	}

}
