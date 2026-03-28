using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexStock.Infrastructure.Data;

namespace NexStock.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
	private readonly NexStockDbContext _db;
	public CategoriaController(NexStockDbContext db)
	{
		_db = db;
	}
	[HttpGet]
	public async Task<IActionResult> GetCategorias()
	{
		var categorias = await _db.Categorias
			.OrderBy(c => c.Nome)
			.Select(c => new { c.Id, c.Nome })
			.ToListAsync();
		return Ok(categorias);
	}
}
