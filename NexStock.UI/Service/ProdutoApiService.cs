using NexStock.UI.Service;

using System.Net.Http.Json;

using System.Text.Json;

namespace NexStock.UI.Services

{

    public class ProdutoApiService

    {

        private readonly HttpClient _http = ApiClientService.Cliente;

        public async Task<List<Application.DTOs.ProdutoDto>> ListarProdutosAsync()

        {

            try

            {

                var lista = await _http.GetFromJsonAsync<List<Application.DTOs.ProdutoDto>>("api/produto");

                return lista ?? new List<Application.DTOs.ProdutoDto>();

            }

            catch

            {

                return new List<Application.DTOs.ProdutoDto>();

            }

        }

        public async Task<Application.DTOs.ProdutoDto?> BuscarProdutoPorIdAsync(int id)

        {

            try

            {

                var response = await _http.GetAsync($"api/produto/{id}");

                if (!response.IsSuccessStatusCode)

                    return null;

                return await response.Content.ReadFromJsonAsync<Application.DTOs.ProdutoDto>();

            }

            catch

            {

                return null;

            }

        }

        public async Task<Application.DTOs.ProdutoDto?> CadastrarProdutoAsync(

            string nome,

            string unidade,

            int quantidade,

            int estoqueMinimo,

            int categoriaId,

            int localizacaoId)

        {

            try

            {

                var payload = new Application.DTOs.CriarProdutoDto

                {

                    Nome = nome,

                    Unidade = unidade,

                    Quantidade = quantidade,

                    EstoqueMinimo = estoqueMinimo,

                    CategoriaId = categoriaId,

                    LocalizacaoId = localizacaoId

                };

                var response = await _http.PostAsJsonAsync("api/produto", payload);

                if (response.IsSuccessStatusCode)

                    return await response.Content.ReadFromJsonAsync<Application.DTOs.ProdutoDto>();

                return null;

            }

            catch

            {

                return null;

            }

        }

        public async Task<bool> AtualizarProdutoAsync(int id, Application.DTOs.AtualizarProdutoDto dto)

        {

            try

            {

                var response = await _http.PutAsJsonAsync($"api/produto/{id}", dto);

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

        }

		public async Task<bool> ExcluirProdutoAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/produto/{id}");

			if (response.IsSuccessStatusCode)
				return true;

			var erro = await response.Content.ReadAsStringAsync();
			var mensagem = ExtrairMensagemErro(erro);

			throw new Exception(string.IsNullOrWhiteSpace(mensagem)
				? "Não foi possível excluir o produto."
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
