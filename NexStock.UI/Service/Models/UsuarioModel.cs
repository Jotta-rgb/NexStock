using System;
using System.Collections.Generic;
using System.Text;

namespace NexStock.UI.Service.Models
{
	public class UsuarioDto
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Perfil { get; set; } = string.Empty;
	}

	public class loginDto
	{
		public string Email { get; set; } = string.Empty;
		public string Senha {  get; set; } = string.Empty;
	}

    public class LoginResponseDto
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty ;

		public bool Sucesso { get; set; }

		public string Mensagem { get; set; } = string.Empty;	

	}

    }

