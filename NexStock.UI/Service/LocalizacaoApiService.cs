using NexStock.UI.Service;

using System.Net.Http.Json;

using System.Text.Json;

namespace NexStock.UI.Services

{

    public class LocalizacaoApiService

    {

        private readonly HttpClient _http = ApiClientService.Cliente;

        public async Task<List<Application.DTOs.LocalizacaoDto>> ListarLocalizacoesAsync()

        {

            try

            {

                var lista = await _http.GetFromJsonAsync<List<Application.DTOs.LocalizacaoDto>>("api/localizacao");

                return lista ?? new List<Application.DTOs.LocalizacaoDto>();

            }

            catch

            {

                return new List<Application.DTOs.LocalizacaoDto>();

            }

        }

        public async Task<Application.DTOs.LocalizacaoDto?> BuscarLocalizacaoPorIdAsync(int id)

        {

            try

            {

                var response = await _http.GetAsync($"api/localizacao/{id}");

                if (!response.IsSuccessStatusCode)

                    return null;

                return await response.Content.ReadFromJsonAsync<Application.DTOs.LocalizacaoDto>();

            }

            catch

            {

                return null;

            }

        }

        public async Task<Application.DTOs.LocalizacaoDto?> CadastrarLocalizacaoAsync(string nome)

        {

            try

            {

                var payload = new Application.DTOs.CriarLocalizacaoDto

                {

                    Nome = nome

                };

                var response = await _http.PostAsJsonAsync("api/localizacao", payload);

                if (response.IsSuccessStatusCode)

                    return await response.Content.ReadFromJsonAsync<Application.DTOs.LocalizacaoDto>();

                return null;

            }

            catch

            {

                return null;

            }

        }

        public async Task<bool> AtualizarLocalizacaoAsync(int id, string nome)

        {

            try

            {

                var payload = new Application.DTOs.AtualizarLocalizacaoDto

                {

                    Nome = nome

                };

                var response = await _http.PutAsJsonAsync($"api/localizacao/{id}", payload);

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

        }

		public async Task<bool> ExcluirLocalizacaoAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/localizacao/{id}");

			if (response.IsSuccessStatusCode)
				return true;

			var erro = await response.Content.ReadAsStringAsync();
			var mensagem = ExtrairMensagemErro(erro);

			throw new Exception(string.IsNullOrWhiteSpace(mensagem)
				? "Não foi possível excluir a localização."
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
