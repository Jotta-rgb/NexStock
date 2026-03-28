using System.Security.Cryptography;

using System.Text;

using NexStock.Application.DTOs;

using NexStock.Domain.Entities;

using NexStock.Domain.Interfaces;

namespace NexStock.Application.Services;

public class UsuarioService

{

	private readonly IUsuarioRepository _usuarioRepository;

	public UsuarioService(IUsuarioRepository usuarioRepository)

	{

		_usuarioRepository = usuarioRepository;

	}

	public async Task<LoginResponseDto> AutenticarAsync(LoginDto loginDto)

	{

		var usuario = await _usuarioRepository.ObterPorEmailAsync(loginDto.Email);

		if (usuario == null)

		{

			return new LoginResponseDto

			{

				Sucesso = false,

				Mensagem = "Email não encontrado."

			};

		}

		var senhaHashFornecida = GerarHash(loginDto.Senha);

		if (usuario.SenhaHash != senhaHashFornecida)

		{

			return new LoginResponseDto

			{

				Sucesso = false,

				Mensagem = "Senha incorreta."

			};

		}

		return new LoginResponseDto

		{

			Id = usuario.Id,

			Email = usuario.Email,

			Sucesso = true,

			Mensagem = "Login realizado com sucesso."

		};

	}

	public async Task<UsuarioDto> CriarAsync(CriarUsuarioDto dto)

	{

		var existente = await _usuarioRepository.ObterPorEmailAsync(dto.Email);

		if (existente != null)

			throw new InvalidOperationException($"Já existe um usuário com o email '{dto.Email}'.");

		var usuario = new Usuario

		{

			Email = dto.Email,

			SenhaHash = GerarHash(dto.Senha)

		};

		await _usuarioRepository.AdicionarAsync(usuario);

		return new UsuarioDto

		{

			Id = usuario.Id,

			Email = usuario.Email

		};

	}

	public async Task<IEnumerable<UsuarioDto>> ListarTodosAsync()

	{

		var usuarios = await _usuarioRepository.ListarTodosAsync();

		return usuarios.Select(u => new UsuarioDto

		{

			Id = u.Id,

			Email = u.Email

		});

	}

	public async Task<UsuarioDto?> ObterPorIdAsync(int id)

	{

		var usuario = await _usuarioRepository.ObterPorIdAsync(id);

		if (usuario == null) return null;

		return new UsuarioDto

		{

			Id = usuario.Id,

			Email = usuario.Email

		};

	}

	public async Task RemoverAsync(int id)

	{

		var usuario = await _usuarioRepository.ObterPorIdAsync(id);

		if (usuario == null)

			throw new KeyNotFoundException($"Usuário com Id {id} não encontrado.");

		await _usuarioRepository.RemoverAsync(id);

	}

	public async Task<UsuarioDto?> UpdateAsync(UsuarioDto dto)

	{

		var usuario = await _usuarioRepository.ObterPorIdAsync(dto.Id);

		if (usuario == null)

			return null;

		usuario.Email = dto.Email;

		await _usuarioRepository.AtualizarAsync(usuario);

		return new UsuarioDto

		{

			Id = usuario.Id,

			Email = usuario.Email

		};

	}

	private static string GerarHash(string texto)

	{

		var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));

		return Convert.ToHexString(bytes).ToLower();

	}

}
