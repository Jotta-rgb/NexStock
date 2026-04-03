using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NexStock.Web.Models;

namespace NexStock.Web.Controllers;

public class MovimentacaoController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public MovimentacaoController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	private bool IsLogged()
	{
		return HttpContext.Session.GetInt32("UsuarioId").HasValue;
	}

	public override void OnActionExecuting(ActionExecutingContext context)
	{
		if (!IsLogged())
		{
			context.Result = new RedirectToActionResult("Login", "Usuario", null);
			return;
		}

		base.OnActionExecuting(context);
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient("NexStockApi");

		var movimentacoes = await client.GetFromJsonAsync<List<MovimentacaoModel>>("/api/movimentacao")
						   ?? new List<MovimentacaoModel>();

		var produtos = await client.GetFromJsonAsync<List<ProdutoModel>>("/api/produto")
					  ?? new List<ProdutoModel>();

		ViewBag.Produtos = produtos;

		return View(movimentacoes);
	}

	[HttpPost]
	public async Task<IActionResult> Create(string tipo, int produtoId, int quantidade, string responsavel, string? notaFiscal)
	{
		var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

		if (!usuarioId.HasValue)
			return RedirectToAction("Login", "Usuario");

		var client = _httpClientFactory.CreateClient("NexStockApi");

		var payload = new CriarMovimentacaoModel
		{
			Tipo = tipo,
			ProdutoId = produtoId,
			Quantidade = quantidade,
			Responsavel = responsavel,
			NotaFiscal = notaFiscal,
			UsuarioId = usuarioId.Value
		};

		var response = await client.PostAsJsonAsync("/api/movimentacao", payload);

		if (!response.IsSuccessStatusCode)
			TempData["Erro"] = "Não foi possível registrar a movimentação.";
		else
			TempData["Sucesso"] = "Movimentação registrada com sucesso.";

		return RedirectToAction(nameof(Index));
	}
}
