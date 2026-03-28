using Microsoft.AspNetCore.Mvc;

using NexStock.Application.DTOs;

using NexStock.Application.Services;

namespace NexStock.API.Controllers;

[ApiController]

[Route("api/[controller]")]

public class LocalizacaoController : ControllerBase

{

	private readonly LocalizacaoService _localizacaoService;

	public LocalizacaoController(LocalizacaoService localizacaoService)

	{

		_localizacaoService = localizacaoService;

	}

	[HttpGet]

	public async Task<IActionResult> ListarTodos()

	{

		var localizacoes = await _localizacaoService.ListarTodosAsync();

		return Ok(localizacoes);

	}

	[HttpGet("{id}")]

	public async Task<IActionResult> ObterPorId(int id)

	{

		var localizacao = await _localizacaoService.ObterPorIdAsync(id);

		if (localizacao == null)

			return NotFound(new { mensagem = $"Localização {id} não encontrada." });

		return Ok(localizacao);

	}

	[HttpPost]

	public async Task<IActionResult> Criar([FromBody] CriarLocalizacaoDto dto)

	{

		try

		{

			var localizacao = await _localizacaoService.CriarAsync(dto);

			return CreatedAtAction(nameof(ObterPorId), new { id = localizacao.Id }, localizacao);

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

	public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarLocalizacaoDto dto)

	{

		try

		{

			await _localizacaoService.AtualizarAsync(id, dto);

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

			await _localizacaoService.RemoverAsync(id);

			return NoContent();

		}

		catch (KeyNotFoundException ex)

		{

			return NotFound(new { mensagem = ex.Message });

		}

	}

}
