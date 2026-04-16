using NexStock.UI.Service;
using NexStock.UI.Service.Models;
using System.Net.Http.Json;

namespace NexStock.UI.Services;

public class DashboardApiService
{
    private readonly HttpClient _http = ApiClientService.Cliente;

    public async Task<DashboardDto?> ObterDashboardAsync()
    {
        try
        {
            var dashboard = await _http.GetFromJsonAsync<DashboardDto>("api/dashboard");
            return dashboard;
        }
        catch
        {
            return null;
        }
    }
}