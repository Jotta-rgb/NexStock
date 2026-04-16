using Microsoft.AspNetCore.Mvc;

using NexStock.Application.DTOs;

using NexStock.Application.Services;

namespace NexStock.API.Controllers;

[ApiController]

[Route("api/[controller]")]

public class UsuarioController : ControllerBase

{

	private readonly UsuarioService _usuarioService;

	public UsuarioController(UsuarioService usuarioService)

	{

		_usuarioService = usuarioService;

	}

	[HttpPost("login")]

	public async Task<IActionResult> Login([FromBody] LoginDto loginDto)

	{

		try

		{

			var resultado = await _usuarioService.AutenticarAsync(loginDto);

			if (!resultado.Sucesso)

				return Unauthorized(resultado);

			return Ok(resultado);

		}

		catch (Exception ex)

		{

			return BadRequest(new { mensagem = ex.Message });

		}

	}

	[HttpGet]

	public async Task<IActionResult> ListarTodos()

	{

		var usuarios = await _usuarioService.ListarTodosAsync();

		return Ok(usuarios);

	}

	[HttpGet("{id}")]

	public async Task<IActionResult> ObterPorId(int id)

	{

		var usuario = await _usuarioService.ObterPorIdAsync(id);

		if (usuario == null)

		{

			return NotFound(new { mensagem = $"Usuário {id} não foi encontrado" });

		}

		return Ok(usuario);

	}

	[HttpPost]

	public async Task<IActionResult> Criar([FromBody] CriarUsuarioDto dto)

	{

		try

		{

			var usuario = await _usuarioService.CriarAsync(dto);

			return CreatedAtAction(nameof(ListarTodos), new { id = usuario.Id }, usuario);

		}

		catch (Exception ex)

		{

			return Conflict(new { mensagem = ex.Message });

		}

	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Remover(int id)
	{
		try
		{
			await _usuarioService.RemoverAsync(id);
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


	[HttpPut("{id}")]

	public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto dto)

	{

		if (id != dto.Id)

			return BadRequest(new { mensagem = "O ID da rota não corresponde o ID do corpo da requisição" });

		var usuarioAtualizado = await _usuarioService.UpdateAsync(dto);

		if (usuarioAtualizado == null)

			return NotFound(new { mensagem = $"Usuário {id} não foi encontrado" });

		return Ok(usuarioAtualizado);

	}

}
