using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NexStock.Domain.Entities;

namespace NexStock.Infrastructure.Data;

public static class DatabaseSeeder
{
	public static async Task SeedAsync(NexStockDbContext db)
	{
		await db.Database.MigrateAsync();

		await SeedUsuariosAsync(db);
		await SeedCategoriasAsync(db);
		await SeedLocalizacoesAsync(db);
		await SeedProdutosAsync(db);
		await SeedMovimentacoesAsync(db);
	}

	private static async Task SeedUsuariosAsync(NexStockDbContext db)
	{
		var usuarios = new List<Usuario>
		{
			new Usuario { Email = "admin@nexstock.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "usuario@nexstock.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "almoxarife1@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "almoxarife2@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "compras@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "rh@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "producao@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "manutencao@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "qualidade@driveline.com", SenhaHash = GerarHash("1234") },
			new Usuario { Email = "estoque@driveline.com", SenhaHash = GerarHash("1234") }
		};

		foreach (var usuario in usuarios)
		{
			var existe = await db.Usuarios.AnyAsync(u => u.Email == usuario.Email);
			if (!existe)
				db.Usuarios.Add(usuario);
		}

		await db.SaveChangesAsync();
	}

	private static async Task SeedCategoriasAsync(NexStockDbContext db)
	{
		var categorias = new List<Categoria>
		{
			new Categoria { Nome = "EPI" },
			new Categoria { Nome = "Material de Escritório" },
			new Categoria { Nome = "Limpeza" },
			new Categoria { Nome = "Uniformes" },
			new Categoria { Nome = "Ferramentas" },
			new Categoria { Nome = "Elétrica" },
			new Categoria { Nome = "Fixação" },
			new Categoria { Nome = "Hidráulica" },
			new Categoria { Nome = "Manutenção" },
			new Categoria { Nome = "Embalagem" }
		};

		foreach (var categoria in categorias)
		{
			var existe = await db.Categorias.AnyAsync(c => c.Nome == categoria.Nome);
			if (!existe)
				db.Categorias.Add(categoria);
		}

		await db.SaveChangesAsync();
	}

	private static async Task SeedLocalizacoesAsync(NexStockDbContext db)
	{
		var localizacoes = new List<Localizacao>
		{
			new Localizacao { Nome = "Prateleira A1" },
			new Localizacao { Nome = "Prateleira A2" },
			new Localizacao { Nome = "Prateleira B1" },
			new Localizacao { Nome = "Prateleira B2" },
			new Localizacao { Nome = "Caixa C1" },
			new Localizacao { Nome = "Caixa C2" },
			new Localizacao { Nome = "Armário D1" },
			new Localizacao { Nome = "Armário D2" },
			new Localizacao { Nome = "Corredor E1" },
			new Localizacao { Nome = "Estante F1" }
		};

		foreach (var localizacao in localizacoes)
		{
			var existe = await db.Localizacoes.AnyAsync(l => l.Nome == localizacao.Nome);
			if (!existe)
				db.Localizacoes.Add(localizacao);
		}

		await db.SaveChangesAsync();
	}

	private static async Task SeedProdutosAsync(NexStockDbContext db)
	{
		var categorias = await db.Categorias.ToDictionaryAsync(c => c.Nome, c => c.Id);
		var localizacoes = await db.Localizacoes.ToDictionaryAsync(l => l.Nome, l => l.Id);

		var produtos = new List<Produto>
		{
			new Produto
			{
				Nome = "Luva de Proteção",
				Unidade = "par",
				Quantidade = 120,
				EstoqueMinimo = 20,
				CategoriaId = categorias["EPI"],
				LocalizacaoId = localizacoes["Prateleira A1"]
			},
			new Produto
			{
				Nome = "Óculos de Segurança",
				Unidade = "un",
				Quantidade = 80,
				EstoqueMinimo = 15,
				CategoriaId = categorias["EPI"],
				LocalizacaoId = localizacoes["Prateleira A2"]
			},
			new Produto
			{
				Nome = "Caneta Esferográfica Azul",
				Unidade = "cx",
				Quantidade = 35,
				EstoqueMinimo = 10,
				CategoriaId = categorias["Material de Escritório"],
				LocalizacaoId = localizacoes["Armário D1"]
			},
			new Produto
			{
				Nome = "Papel A4",
				Unidade = "resma",
				Quantidade = 60,
				EstoqueMinimo = 12,
				CategoriaId = categorias["Material de Escritório"],
				LocalizacaoId = localizacoes["Armário D2"]
			},
			new Produto
			{
				Nome = "Detergente Industrial",
				Unidade = "un",
				Quantidade = 25,
				EstoqueMinimo = 8,
				CategoriaId = categorias["Limpeza"],
				LocalizacaoId = localizacoes["Caixa C1"]
			},
			new Produto
			{
				Nome = "Uniforme Operacional",
				Unidade = "un",
				Quantidade = 40,
				EstoqueMinimo = 10,
				CategoriaId = categorias["Uniformes"],
				LocalizacaoId = localizacoes["Caixa C2"]
			},
			new Produto
			{
				Nome = "Chave Allen Jogo",
				Unidade = "kit",
				Quantidade = 18,
				EstoqueMinimo = 5,
				CategoriaId = categorias["Ferramentas"],
				LocalizacaoId = localizacoes["Prateleira B1"]
			},
			new Produto
			{
				Nome = "Fita Isolante",
				Unidade = "rolo",
				Quantidade = 50,
				EstoqueMinimo = 10,
				CategoriaId = categorias["Elétrica"],
				LocalizacaoId = localizacoes["Prateleira B2"]
			},
			new Produto
			{
				Nome = "Parafuso Sextavado",
				Unidade = "un",
				Quantidade = 500,
				EstoqueMinimo = 100,
				CategoriaId = categorias["Fixação"],
				LocalizacaoId = localizacoes["Corredor E1"]
			},
			new Produto
			{
				Nome = "Caixa de Papelão Média",
				Unidade = "un",
				Quantidade = 90,
				EstoqueMinimo = 20,
				CategoriaId = categorias["Embalagem"],
				LocalizacaoId = localizacoes["Estante F1"]
			}
		};

		foreach (var produto in produtos)
		{
			var existe = await db.Produtos.AnyAsync(p => p.Nome == produto.Nome);
			if (!existe)
				db.Produtos.Add(produto);
		}

		await db.SaveChangesAsync();
	}

	private static async Task SeedMovimentacoesAsync(NexStockDbContext db)
	{
		if (await db.Movimentacoes.AnyAsync()) return;

		var produtos = await db.Produtos.ToDictionaryAsync(p => p.Nome, p => p.Id);
		var usuarios = await db.Usuarios.ToDictionaryAsync(u => u.Email, u => u.Id);

		var movimentacoes = new List<Movimentacao>
		{
			new Movimentacao
			{
				Tipo = "entrada",
				Quantidade = 30,
				Responsavel = "Setor de Compras",
				NotaFiscal = "NF-1001",
				Data = DateTime.Now.AddDays(-10),
				ProdutoId = produtos["Luva de Proteção"],
				UsuarioId = usuarios["compras@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "saida",
				Quantidade = 12,
				Responsavel = "Carlos Lima",
				NotaFiscal = "REQ-2001",
				Data = DateTime.Now.AddDays(-9),
				ProdutoId = produtos["Óculos de Segurança"],
				UsuarioId = usuarios["almoxarife1@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "entrada",
				Quantidade = 20,
				Responsavel = "Setor Administrativo",
				NotaFiscal = "NF-1002",
				Data = DateTime.Now.AddDays(-8),
				ProdutoId = produtos["Caneta Esferográfica Azul"],
				UsuarioId = usuarios["admin@nexstock.com"]
			},
			new Movimentacao
			{
				Tipo = "saida",
				Quantidade = 8,
				Responsavel = "Fernanda Souza",
				NotaFiscal = "REQ-2002",
				Data = DateTime.Now.AddDays(-7),
				ProdutoId = produtos["Papel A4"],
				UsuarioId = usuarios["usuario@nexstock.com"]
			},
			new Movimentacao
			{
				Tipo = "entrada",
				Quantidade = 10,
				Responsavel = "Compras Internas",
				NotaFiscal = "NF-1003",
				Data = DateTime.Now.AddDays(-6),
				ProdutoId = produtos["Detergente Industrial"],
				UsuarioId = usuarios["compras@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "saida",
				Quantidade = 5,
				Responsavel = "Equipe de Limpeza",
				NotaFiscal = "REQ-2003",
				Data = DateTime.Now.AddDays(-5),
				ProdutoId = produtos["Detergente Industrial"],
				UsuarioId = usuarios["estoque@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "entrada",
				Quantidade = 15,
				Responsavel = "RH",
				NotaFiscal = "NF-1004",
				Data = DateTime.Now.AddDays(-4),
				ProdutoId = produtos["Uniforme Operacional"],
				UsuarioId = usuarios["rh@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "saida",
				Quantidade = 3,
				Responsavel = "Equipe de Manutenção",
				NotaFiscal = "REQ-2004",
				Data = DateTime.Now.AddDays(-3),
				ProdutoId = produtos["Chave Allen Jogo"],
				UsuarioId = usuarios["manutencao@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "saida",
				Quantidade = 20,
				Responsavel = "João Pedro",
				NotaFiscal = "REQ-2005",
				Data = DateTime.Now.AddDays(-2),
				ProdutoId = produtos["Fita Isolante"],
				UsuarioId = usuarios["almoxarife2@driveline.com"]
			},
			new Movimentacao
			{
				Tipo = "entrada",
				Quantidade = 100,
				Responsavel = "Recebimento",
				NotaFiscal = "NF-1005",
				Data = DateTime.Now.AddDays(-1),
				ProdutoId = produtos["Caixa de Papelão Média"],
				UsuarioId = usuarios["producao@driveline.com"]
			}
		};

		db.Movimentacoes.AddRange(movimentacoes);
		await db.SaveChangesAsync();
	}

	private static string GerarHash(string texto)
	{
		var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
		return Convert.ToHexString(bytes).ToLower();
	}
}