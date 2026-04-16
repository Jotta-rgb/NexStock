using NexStock.UI.Service;

using System.Net.Http.Json;

using System.Text.Json;

namespace NexStock.UI.Services

{

    public class MovimentacaoApiService

    {

        private readonly HttpClient _http = ApiClientService.Cliente;

        public async Task<List<Application.DTOs.MovimentacaoDto>> ListarMovimentacoesAsync()

        {

            try

            {

                var lista = await _http.GetFromJsonAsync<List<Application.DTOs.MovimentacaoDto>>("api/movimentacao");

                return lista ?? new List<Application.DTOs.MovimentacaoDto>();

            }

            catch

            {

                return new List<Application.DTOs.MovimentacaoDto>();

            }

        }

        public async Task<Application.DTOs.MovimentacaoDto?> BuscarMovimentacaoPorIdAsync(int id)

        {

            try

            {

                var response = await _http.GetAsync($"api/movimentacao/{id}");

                if (!response.IsSuccessStatusCode)

                    return null;

                return await response.Content.ReadFromJsonAsync<Application.DTOs.MovimentacaoDto>();

            }

            catch

            {

                return null;

            }

        }

        public async Task<Application.DTOs.MovimentacaoDto?> CadastrarMovimentacaoAsync(

            string tipo,

            int quantidade,

            string responsavel,

            string? notaFiscal,

            int produtoId,

            int usuarioId)

        {

            try

            {

                var payload = new Application.DTOs.CriarMovimentacaoDto

                {

                    Tipo = tipo,

                    Quantidade = quantidade,

                    Responsavel = responsavel,

                    NotaFiscal = notaFiscal,

                    ProdutoId = produtoId,

                    UsuarioId = usuarioId

                };

                var response = await _http.PostAsJsonAsync("api/movimentacao", payload);

                if (response.IsSuccessStatusCode)

                    return await response.Content.ReadFromJsonAsync<Application.DTOs.MovimentacaoDto>();

                return null;

            }

            catch

            {

                return null;

            }

        }

        public async Task<bool> AtualizarMovimentacaoAsync(int id, Application.DTOs.AtualizarMovimentacaoDto dto)

        {

            try

            {

                var response = await _http.PutAsJsonAsync($"api/movimentacao/{id}", dto);

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

        }

        public async Task<bool> ExcluirMovimentacaoAsync(int id)

        {

            try

            {

                var response = await _http.DeleteAsync($"api/movimentacao/{id}");

                return response.IsSuccessStatusCode;

            }

            catch

            {

                return false;

            }

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
