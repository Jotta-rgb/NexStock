using Microsoft.AspNetCore.Mvc;
using NexStock.Application.Services;

namespace NexStock.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
	private readonly DashboardService _dashboardService;

	public DashboardController(DashboardService dashboardService)
	{
		_dashboardService = dashboardService;
	}

	[HttpGet]
	public async Task<IActionResult> ObterResumo()
	{
		var dashboard = await _dashboardService.ObterResumoAsync();

		if (dashboard == null)
			return NotFound(new { mensagem = "Resumo do dashboard não encontrado." });

		return Ok(dashboard);
	}
}


