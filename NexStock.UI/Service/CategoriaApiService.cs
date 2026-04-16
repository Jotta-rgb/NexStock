using NexStock.UI.Service;

using System.Net.Http.Json;

using System.Text.Json;

namespace NexStock.UI.Services

{

    public class CategoriaApiService

    {

        private readonly HttpClient _http = ApiClientService.Cliente;

		public async Task<List<Application.DTOs.CategoriaDto>> ListarCategoriasAsync()

		{

            try

            {

                var lista = await _http.GetFromJsonAsync<List<Application.DTOs.CategoriaDto>>("api/categoria");

                return lista ?? new List<Application.DTOs.CategoriaDto>();

            }

            catch

            {

                return new List<Application.DTOs.CategoriaDto>();

            }

        }

        public async Task<Application.DTOs.CategoriaDto?> BuscarCategoriaPorIdAsync(int id)

        {

            try

            {

                var response = await _http.GetAsync($"api/categoria/{id}");

                if (!response.IsSuccessStatusCode)

                    return null;

                return await response.Content.ReadFromJsonAsync<Application.DTOs.CategoriaDto>();

            }

            catch

            {

                return null;

            }

        }

        public async Task<Application.DTOs.CategoriaDto?> CadastrarCategoriaAsync(string nome)

        {

            try

            {

                var payload = new Application.DTOs.CriarCategoriaDto

                {

                    Nome = nome

                };

                var response = await _http.PostAsJsonAsync("api/categoria", payload);

                if (response.IsSuccessStatusCode)

                    return await response.Content.ReadFromJsonAsync<Application.DTOs.CategoriaDto>();

                return null;

            }

            catch

            {

                return null;

            }

        }

        public async Task<bool> AtualizarCategoriaAsync(int id, string nome)

        {

            try

            {

                var payload = new Application.DTOs.AtualizarCategoriaDto

                {

                    Nome = nome

                };

                var response = await _http.PutAsJsonAsync($"api/categoria/{id}", payload);

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

        }

		public async Task<bool> ExcluirCategoriaAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/categoria/{id}");

			if (response.IsSuccessStatusCode)
				return true;

			var erro = await response.Content.ReadAsStringAsync();
			var mensagem = ExtrairMensagemErro(erro);

			throw new Exception(string.IsNullOrWhiteSpace(mensagem)
				? "Não foi possível excluir a categoria."
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
