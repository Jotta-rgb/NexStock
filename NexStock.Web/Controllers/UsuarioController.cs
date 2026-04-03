using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using NexStock.Web.Models;

namespace NexStock.Web.Controllers;

public class UsuarioController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public UsuarioController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(string email, string senha)
	{
		var client = _httpClientFactory.CreateClient("NexStockApi");

		var response = await client.PostAsJsonAsync("/api/usuario/login", new
		{
			Email = email,
			Senha = senha
		});

		if (!response.IsSuccessStatusCode)
		{
			ViewBag.Error = "Erro ao tentar autenticar.";
			return View();
		}

		var resultado = await response.Content.ReadFromJsonAsync<LoginResponseModel>();

		if (resultado == null || !resultado.Sucesso)
		{
			ViewBag.Error = resultado?.Mensagem ?? "Credenciais inválidas.";
			return View();
		}

		HttpContext.Session.SetString("UserEmail", resultado.Email);
		HttpContext.Session.SetInt32("UsuarioId", resultado.Id);

		return RedirectToAction("Index", "Movimentacao");
	}

	public IActionResult Logout()
	{
		HttpContext.Session.Clear();
		return RedirectToAction(nameof(Login));
	}
}


