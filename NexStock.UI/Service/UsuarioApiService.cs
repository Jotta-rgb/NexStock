using NexStock.Application.DTOs;
using NexStock.UI.Service;
using NexStock.UI.Service.Models;

using System.Net.Http.Json;

using System.Text.Json;

namespace NexStock.UI.Services

{

    public class UsuarioApiService

    {

        private readonly HttpClient _http = ApiClientService.Cliente;

        public async Task<Application.DTOs.LoginResponseDto?> LoginAsync(string email, string senha)

        {

            try

            {

                var payload = new LoginDto

                {

                    Email = email,

                    Senha = senha

                };

                var response = await _http.PostAsJsonAsync("api/usuario/login", payload);

                if (!response.IsSuccessStatusCode)

                    return null;

                var resultado = await response.Content.ReadFromJsonAsync<Application.DTOs.LoginResponseDto>();

                return resultado;

            }

            catch

            {

                return null;

            }

        }

        public async Task<Application.DTOs.UsuarioDto?> CadastrarUsuarioAsync(string email, string senha)

        {

            try

            {

                var payload = new CriarUsuarioDto

                {

                    Email = email,

                    Senha = senha

                };

                var response = await _http.PostAsJsonAsync("api/usuario", payload);

                if (response.IsSuccessStatusCode)

                    return await response.Content.ReadFromJsonAsync<Application.DTOs.UsuarioDto>();

                return null;

            }

            catch

            {

                return null;

            }

        }

        public async Task<List<Application.DTOs.UsuarioDto>> ListarUsuariosAsync()

        {

            try

            {

                var lista = await _http.GetFromJsonAsync<List<Application.DTOs.UsuarioDto>>("api/usuario");

                return lista ?? new List<Application.DTOs.UsuarioDto>();

            }

            catch

            {

                return new List<Application.DTOs.UsuarioDto>();

            }

        }

        public async Task<Application.DTOs.UsuarioDto?> BuscarUsuarioPorIdAsync(int id)

        {

            try

            {

                var response = await _http.GetAsync($"api/usuario/{id}");

                if (!response.IsSuccessStatusCode)

                    return null;

                return await response.Content.ReadFromJsonAsync<Application.DTOs.UsuarioDto>();

            }

            catch

            {

                return null;

            }

        }

        public async Task<bool> AtualizarUsuarioAsync(int id, AtualizarUsuarioDto dto)

        {

            try

            {

                var response = await _http.PutAsJsonAsync($"api/usuario/{id}", dto);

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

        }

		public async Task<bool> ExcluirUsuarioAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/usuario/{id}");

			if (response.IsSuccessStatusCode)
				return true;

			var erro = await response.Content.ReadAsStringAsync();
			var mensagem = ExtrairMensagemErro(erro);

			throw new Exception(string.IsNullOrWhiteSpace(mensagem)
				? "Não foi possível excluir o usuário."
				: mensagem);
		}



		private static string ExtrairMensagemErro(string json)

        {

            try

            {

                var doc = JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("mensagem", out var mensagem))

                    return mensagem.GetString() ?? json;

            }

            catch

            {

            }

            return json;

        }

    }

}

