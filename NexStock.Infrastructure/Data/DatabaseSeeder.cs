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
			new Usuario { Email = "admin@driveline.com", SenhaHash = GerarHash("123456") },
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
		Nome = "Capacete de Segurança",
		Unidade = "un",
		Quantidade = 70,
		EstoqueMinimo = 15,
		CategoriaId = categorias["EPI"],
		LocalizacaoId = localizacoes["Prateleira A1"]
	},
	new Produto
	{
		Nome = "Protetor Auricular",
		Unidade = "par",
		Quantidade = 150,
		EstoqueMinimo = 30,
		CategoriaId = categorias["EPI"],
		LocalizacaoId = localizacoes["Prateleira A2"]
	},
	new Produto
	{
		Nome = "Máscara PFF2",
		Unidade = "cx",
		Quantidade = 60,
		EstoqueMinimo = 20,
		CategoriaId = categorias["EPI"],
		LocalizacaoId = localizacoes["Prateleira A1"]
	},
	new Produto
	{
		Nome = "Colete Refletivo",
		Unidade = "un",
		Quantidade = 40,
		EstoqueMinimo = 10,
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
		Nome = "Caneta Esferográfica Preta",
		Unidade = "cx",
		Quantidade = 35,
		EstoqueMinimo = 10,
		CategoriaId = categorias["Material de Escritório"],
		LocalizacaoId = localizacoes["Armário D1"]
	},
	new Produto
	{
		Nome = "Marcador Permanente",
		Unidade = "cx",
		Quantidade = 25,
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
		Nome = "Papel A3",
		Unidade = "resma",
		Quantidade = 25,
		EstoqueMinimo = 8,
		CategoriaId = categorias["Material de Escritório"],
		LocalizacaoId = localizacoes["Armário D2"]
	},
	new Produto
	{
		Nome = "Grampeador",
		Unidade = "un",
		Quantidade = 15,
		EstoqueMinimo = 5,
		CategoriaId = categorias["Material de Escritório"],
		LocalizacaoId = localizacoes["Armário D2"]
	},
	new Produto
	{
		Nome = "Caixa de Grampos",
		Unidade = "cx",
		Quantidade = 40,
		EstoqueMinimo = 10,
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
		Nome = "Desengraxante",
		Unidade = "un",
		Quantidade = 30,
		EstoqueMinimo = 10,
		CategoriaId = categorias["Limpeza"],
		LocalizacaoId = localizacoes["Caixa C1"]
	},
	new Produto
	{
		Nome = "Álcool 70%",
		Unidade = "un",
		Quantidade = 45,
		EstoqueMinimo = 12,
		CategoriaId = categorias["Limpeza"],
		LocalizacaoId = localizacoes["Caixa C1"]
	},
	new Produto
	{
		Nome = "Sabão em Pó",
		Unidade = "un",
		Quantidade = 20,
		EstoqueMinimo = 6,
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
		Nome = "Calça Operacional",
		Unidade = "un",
		Quantidade = 30,
		EstoqueMinimo = 8,
		CategoriaId = categorias["Uniformes"],
		LocalizacaoId = localizacoes["Caixa C2"]
	},
	new Produto
	{
		Nome = "Camiseta Operacional",
		Unidade = "un",
		Quantidade = 35,
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
		Nome = "Chave de Fenda",
		Unidade = "un",
		Quantidade = 22,
		EstoqueMinimo = 6,
		CategoriaId = categorias["Ferramentas"],
		LocalizacaoId = localizacoes["Prateleira B1"]
	},
	new Produto
	{
		Nome = "Chave Phillips",
		Unidade = "un",
		Quantidade = 22,
		EstoqueMinimo = 6,
		CategoriaId = categorias["Ferramentas"],
		LocalizacaoId = localizacoes["Prateleira B1"]
	},
	new Produto
	{
		Nome = "Alicate Universal",
		Unidade = "un",
		Quantidade = 15,
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
		Nome = "Conector Elétrico",
		Unidade = "pct",
		Quantidade = 60,
		EstoqueMinimo = 15,
		CategoriaId = categorias["Elétrica"],
		LocalizacaoId = localizacoes["Prateleira B2"]
	},
	new Produto
	{
		Nome = "Cabo Elétrico 2mm",
		Unidade = "rolo",
		Quantidade = 20,
		EstoqueMinimo = 5,
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
		Nome = "Porca Sextavada",
		Unidade = "un",
		Quantidade = 600,
		EstoqueMinimo = 120,
		CategoriaId = categorias["Fixação"],
		LocalizacaoId = localizacoes["Corredor E1"]
	},
	new Produto
	{
		Nome = "Arruela Lisa",
		Unidade = "un",
		Quantidade = 700,
		EstoqueMinimo = 150,
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
	},
	new Produto
	{
		Nome = "Caixa de Papelão Grande",
		Unidade = "un",
		Quantidade = 70,
		EstoqueMinimo = 15,
		CategoriaId = categorias["Embalagem"],
		LocalizacaoId = localizacoes["Estante F1"]
	},
	new Produto
	{
		Nome = "Plástico Bolha",
		Unidade = "rolo",
		Quantidade = 25,
		EstoqueMinimo = 8,
		CategoriaId = categorias["Embalagem"],
		LocalizacaoId = localizacoes["Estante F1"]
	},


	new Produto
{
	Nome = "Luva Nitrílica",
	Unidade = "cx",
	Quantidade = 90,
	EstoqueMinimo = 20,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},
new Produto
{
	Nome = "Protetor Facial",
	Unidade = "un",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A2"]
},
new Produto
{
	Nome = "Avental de Proteção",
	Unidade = "un",
	Quantidade = 40,
	EstoqueMinimo = 12,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},
new Produto
{
	Nome = "Bota de Segurança",
	Unidade = "par",
	Quantidade = 55,
	EstoqueMinimo = 15,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A2"]
},
new Produto
{
	Nome = "Respirador Industrial",
	Unidade = "un",
	Quantidade = 25,
	EstoqueMinimo = 8,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},

new Produto
{
	Nome = "Lápis HB",
	Unidade = "cx",
	Quantidade = 40,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Bloco de Notas",
	Unidade = "un",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Post-it",
	Unidade = "pct",
	Quantidade = 45,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Envelope A4",
	Unidade = "pct",
	Quantidade = 50,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D2"]
},
new Produto
{
	Nome = "Pasta Suspensa",
	Unidade = "cx",
	Quantidade = 30,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D2"]
},

new Produto
{
	Nome = "Água Sanitária",
	Unidade = "un",
	Quantidade = 40,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Desinfetante",
	Unidade = "un",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Pano de Limpeza",
	Unidade = "pct",
	Quantidade = 55,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Vassoura Industrial",
	Unidade = "un",
	Quantidade = 18,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Rodo de Limpeza",
	Unidade = "un",
	Quantidade = 20,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},

new Produto
{
	Nome = "Jaqueta Operacional",
	Unidade = "un",
	Quantidade = 22,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},
new Produto
{
	Nome = "Boné Operacional",
	Unidade = "un",
	Quantidade = 40,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},
new Produto
{
	Nome = "Colete de Trabalho",
	Unidade = "un",
	Quantidade = 30,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},

new Produto
{
	Nome = "Martelo",
	Unidade = "un",
	Quantidade = 15,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Chave Inglesa",
	Unidade = "un",
	Quantidade = 12,
	EstoqueMinimo = 4,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Trena 5m",
	Unidade = "un",
	Quantidade = 20,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Estilete",
	Unidade = "un",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Serrote",
	Unidade = "un",
	Quantidade = 10,
	EstoqueMinimo = 4,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},

new Produto
{
	Nome = "Interruptor Simples",
	Unidade = "un",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Tomada 2P+T",
	Unidade = "un",
	Quantidade = 70,
	EstoqueMinimo = 18,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Disjuntor 20A",
	Unidade = "un",
	Quantidade = 25,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},

new Produto
{
	Nome = "Parafuso Allen",
	Unidade = "un",
	Quantidade = 450,
	EstoqueMinimo = 100,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Parafuso Philips",
	Unidade = "un",
	Quantidade = 400,
	EstoqueMinimo = 90,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Porca Travante",
	Unidade = "un",
	Quantidade = 380,
	EstoqueMinimo = 80,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Arruela de Pressão",
	Unidade = "un",
	Quantidade = 420,
	EstoqueMinimo = 100,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},

new Produto
{
	Nome = "Fita Adesiva Larga",
	Unidade = "rolo",
	Quantidade = 80,
	EstoqueMinimo = 20,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Fita Crepe",
	Unidade = "rolo",
	Quantidade = 70,
	EstoqueMinimo = 18,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Envelope Plástico",
	Unidade = "pct",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Etiqueta Adesiva",
	Unidade = "pct",
	Quantidade = 45,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Filme Stretch",
	Unidade = "rolo",
	Quantidade = 30,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},

new Produto
{
	Nome = "Luva Anticorte",
	Unidade = "par",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},
new Produto
{
	Nome = "Protetor Auricular Tipo Plug",
	Unidade = "cx",
	Quantidade = 120,
	EstoqueMinimo = 30,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A2"]
},
new Produto
{
	Nome = "Máscara Descartável",
	Unidade = "cx",
	Quantidade = 85,
	EstoqueMinimo = 20,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},

new Produto
{
	Nome = "Pasta Catálogo",
	Unidade = "un",
	Quantidade = 45,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Etiqueta Adesiva A4",
	Unidade = "pct",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D2"]
},
new Produto
{
	Nome = "Tesoura de Escritório",
	Unidade = "un",
	Quantidade = 18,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},

new Produto
{
	Nome = "Desengordurante Industrial",
	Unidade = "un",
	Quantidade = 28,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Limpador Multiuso",
	Unidade = "un",
	Quantidade = 30,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Flanela de Limpeza",
	Unidade = "pct",
	Quantidade = 50,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},

new Produto
{
	Nome = "Camisa Social Operacional",
	Unidade = "un",
	Quantidade = 20,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},
new Produto
{
	Nome = "Calça Brim Operacional",
	Unidade = "un",
	Quantidade = 24,
	EstoqueMinimo = 7,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},

new Produto
{
	Nome = "Chave Estrela",
	Unidade = "un",
	Quantidade = 14,
	EstoqueMinimo = 4,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Jogo de Soquetes",
	Unidade = "kit",
	Quantidade = 9,
	EstoqueMinimo = 3,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Torquímetro",
	Unidade = "un",
	Quantidade = 6,
	EstoqueMinimo = 2,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},

new Produto
{
	Nome = "Fio Elétrico 1,5mm",
	Unidade = "rolo",
	Quantidade = 18,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Fio Elétrico 4mm",
	Unidade = "rolo",
	Quantidade = 16,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Disjuntor 10A",
	Unidade = "un",
	Quantidade = 30,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},

new Produto
{
	Nome = "Arruela M6",
	Unidade = "un",
	Quantidade = 700,
	EstoqueMinimo = 180,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Arruela M8",
	Unidade = "un",
	Quantidade = 680,
	EstoqueMinimo = 170,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Arruela M10",
	Unidade = "un",
	Quantidade = 640,
	EstoqueMinimo = 160,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},

new Produto
{
	Nome = "Fita Gomada",
	Unidade = "rolo",
	Quantidade = 55,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Caixa Arquivo Morto",
	Unidade = "un",
	Quantidade = 48,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Envelope Bolha",
	Unidade = "pct",
	Quantidade = 65,
	EstoqueMinimo = 18,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},




new Produto
{
	Nome = "Luva Térmica",
	Unidade = "par",
	Quantidade = 45,
	EstoqueMinimo = 10,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},
new Produto
{
	Nome = "Capuz de Proteção",
	Unidade = "un",
	Quantidade = 25,
	EstoqueMinimo = 8,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A2"]
},
new Produto
{
	Nome = "Óculos Ampla Visão",
	Unidade = "un",
	Quantidade = 50,
	EstoqueMinimo = 15,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A1"]
},
new Produto
{
	Nome = "Protetor Solar Industrial",
	Unidade = "un",
	Quantidade = 30,
	EstoqueMinimo = 8,
	CategoriaId = categorias["EPI"],
	LocalizacaoId = localizacoes["Prateleira A2"]
},

new Produto
{
	Nome = "Caderno Universitário",
	Unidade = "un",
	Quantidade = 40,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Calculadora de Mesa",
	Unidade = "un",
	Quantidade = 15,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D1"]
},
new Produto
{
	Nome = "Clips Metálicos",
	Unidade = "cx",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D2"]
},
new Produto
{
	Nome = "Grampo Trilho",
	Unidade = "cx",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Material de Escritório"],
	LocalizacaoId = localizacoes["Armário D2"]
},

new Produto
{
	Nome = "Esponja de Limpeza",
	Unidade = "pct",
	Quantidade = 55,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Luva de Limpeza",
	Unidade = "par",
	Quantidade = 40,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},
new Produto
{
	Nome = "Baldes de Limpeza",
	Unidade = "un",
	Quantidade = 18,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Limpeza"],
	LocalizacaoId = localizacoes["Caixa C1"]
},

new Produto
{
	Nome = "Camiseta Polo Operacional",
	Unidade = "un",
	Quantidade = 35,
	EstoqueMinimo = 10,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},
new Produto
{
	Nome = "Calça Jeans Operacional",
	Unidade = "un",
	Quantidade = 28,
	EstoqueMinimo = 8,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},
new Produto
{
	Nome = "Cinto Operacional",
	Unidade = "un",
	Quantidade = 20,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Uniformes"],
	LocalizacaoId = localizacoes["Caixa C2"]
},

new Produto
{
	Nome = "Alicate de Corte",
	Unidade = "un",
	Quantidade = 16,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Chave Torx",
	Unidade = "un",
	Quantidade = 14,
	EstoqueMinimo = 5,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Nível de Bolha",
	Unidade = "un",
	Quantidade = 10,
	EstoqueMinimo = 4,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},
new Produto
{
	Nome = "Arco de Serra",
	Unidade = "un",
	Quantidade = 12,
	EstoqueMinimo = 4,
	CategoriaId = categorias["Ferramentas"],
	LocalizacaoId = localizacoes["Prateleira B1"]
},

new Produto
{
	Nome = "Extensão Elétrica",
	Unidade = "un",
	Quantidade = 22,
	EstoqueMinimo = 6,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Plug Macho",
	Unidade = "un",
	Quantidade = 70,
	EstoqueMinimo = 20,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},
new Produto
{
	Nome = "Plug Fêmea",
	Unidade = "un",
	Quantidade = 70,
	EstoqueMinimo = 20,
	CategoriaId = categorias["Elétrica"],
	LocalizacaoId = localizacoes["Prateleira B2"]
},

new Produto
{
	Nome = "Parafuso M6",
	Unidade = "un",
	Quantidade = 600,
	EstoqueMinimo = 150,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Parafuso M8",
	Unidade = "un",
	Quantidade = 550,
	EstoqueMinimo = 140,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Parafuso M10",
	Unidade = "un",
	Quantidade = 500,
	EstoqueMinimo = 130,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Porca M6",
	Unidade = "un",
	Quantidade = 650,
	EstoqueMinimo = 160,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},
new Produto
{
	Nome = "Porca M8",
	Unidade = "un",
	Quantidade = 620,
	EstoqueMinimo = 150,
	CategoriaId = categorias["Fixação"],
	LocalizacaoId = localizacoes["Corredor E1"]
},

new Produto
{
	Nome = "Caixa de Papelão Pequena",
	Unidade = "un",
	Quantidade = 95,
	EstoqueMinimo = 25,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Caixa de Papelão Extra Grande",
	Unidade = "un",
	Quantidade = 60,
	EstoqueMinimo = 15,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Etiqueta Térmica",
	Unidade = "rolo",
	Quantidade = 40,
	EstoqueMinimo = 12,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Saco Plástico Grande",
	Unidade = "pct",
	Quantidade = 75,
	EstoqueMinimo = 20,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Saco Plástico Médio",
	Unidade = "pct",
	Quantidade = 85,
	EstoqueMinimo = 22,
	CategoriaId = categorias["Embalagem"],
	LocalizacaoId = localizacoes["Estante F1"]
},
new Produto
{
	Nome = "Saco Plástico Pequeno",
	Unidade = "pct",
	Quantidade = 90,
	EstoqueMinimo = 25,
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
		//if (await db.Movimentacoes.AnyAsync()) return;


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
			},

			new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1101",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Capacete de Segurança"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 12,
	Responsavel = "Almoxarifado",
	NotaFiscal = "REQ-2101",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Capacete de Segurança"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 25,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1102",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Protetor Auricular"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 18,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2102",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Protetor Auricular"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1103",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Máscara PFF2"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Segurança do Trabalho",
	NotaFiscal = "REQ-2103",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Máscara PFF2"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1104",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Colete Refletivo"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 8,
	Responsavel = "Expedição",
	NotaFiscal = "REQ-2104",
		Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Colete Refletivo"],
	UsuarioId = usuarios["producao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 30,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1105",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Caneta Esferográfica Preta"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 12,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2105",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Caneta Esferográfica Preta"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1106",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Marcador Permanente"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Escritório",
	NotaFiscal = "REQ-2106",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Marcador Permanente"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1107",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Papel A3"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Financeiro",
	NotaFiscal = "REQ-2107",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Papel A3"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 8,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1108",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Grampeador"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "RH",
	NotaFiscal = "REQ-2108",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Grampeador"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1109",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Caixa de Grampos"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 7,
	Responsavel = "RH",
	NotaFiscal = "REQ-2109",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Caixa de Grampos"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 25,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1110",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Luva Nitrílica"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2110",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Luva Nitrílica"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1111",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Protetor Facial"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 5,
	Responsavel = "Solda",
	NotaFiscal = "REQ-2111",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Protetor Facial"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1112",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Avental de Proteção"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Limpeza Técnica",
	NotaFiscal = "REQ-2112",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Avental de Proteção"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1113",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Bota de Segurança"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 7,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2113",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Bota de Segurança"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 9,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1114",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Respirador Industrial"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 4,
	Responsavel = "Pintura",
	NotaFiscal = "REQ-2114",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Respirador Industrial"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1115",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Lápis HB"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2115",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Lápis HB"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},

new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 14,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1201",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Desengraxante"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2201",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Desengraxante"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1202",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Álcool 70%"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2202",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Álcool 70%"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1203",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Sabão em Pó"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2203",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Sabão em Pó"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 22,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1204",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Água Sanitária"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2204",
	Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Água Sanitária"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1205",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Desinfetante"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2205",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Desinfetante"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1206",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Pano de Limpeza"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2206",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Pano de Limpeza"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1207",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Vassoura Industrial"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2207",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Vassoura Industrial"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "Compras Internas",
	NotaFiscal = "NF-1208",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Rodo de Limpeza"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 4,
	Responsavel = "Equipe de Limpeza",
	NotaFiscal = "REQ-2208",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Rodo de Limpeza"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "RH",
	NotaFiscal = "NF-1209",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Calça Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 8,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2209",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Calça Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "RH",
	NotaFiscal = "NF-1210",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Camiseta Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 7,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2210",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Camiseta Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "RH",
	NotaFiscal = "NF-1211",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Jaqueta Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Expedição",
	NotaFiscal = "REQ-2211",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Jaqueta Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "RH",
	NotaFiscal = "NF-1212",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Boné Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2212",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Boné Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 8,
	Responsavel = "RH",
	NotaFiscal = "NF-1213",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Colete de Trabalho"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 5,
	Responsavel = "Expedição",
	NotaFiscal = "REQ-2213",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Colete de Trabalho"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 5,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1214",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Chave de Fenda"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 2,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2214",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Chave de Fenda"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 5,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1215",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Chave Phillips"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2215",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Chave Phillips"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},

new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 4,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1301",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Alicate Universal"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 2,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2301",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Alicate Universal"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1302",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Martelo"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2302",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Martelo"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 4,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1303",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Chave Inglesa"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 2,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2303",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Chave Inglesa"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 7,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1304",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Trena 5m"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2304",
	Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Trena 5m"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1305",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Estilete"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Almoxarifado",
	NotaFiscal = "REQ-2305",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Estilete"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 4,
	Responsavel = "Manutenção",
	NotaFiscal = "NF-1306",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Serrote"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 2,
	Responsavel = "Manutenção",
	NotaFiscal = "REQ-2306",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Serrote"],
	UsuarioId = usuarios["manutencao@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1307",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Conector Elétrico"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 8,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2307",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Conector Elétrico"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 5,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1308",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Cabo Elétrico 2mm"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 3,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2308",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Cabo Elétrico 2mm"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 14,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1309",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Interruptor Simples"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2309",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Interruptor Simples"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1310",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Tomada 2P+T"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2310",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Tomada 2P+T"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 7,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1311",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Disjuntor 20A"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 4,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2311",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Disjuntor 20A"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1312",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Fio Elétrico 1,5mm"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 4,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2312",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Fio Elétrico 1,5mm"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 6,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1313",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Fio Elétrico 4mm"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 4,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2313",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Fio Elétrico 4mm"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 8,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1314",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Disjuntor 10A"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 5,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2314",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Disjuntor 10A"],
	UsuarioId = usuarios["estoque@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "Setor Elétrico",
	NotaFiscal = "NF-1315",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Extensão Elétrica"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Equipe Elétrica",
	NotaFiscal = "REQ-2315",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Extensão Elétrica"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},

new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 120,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1401",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Parafuso Allen"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 90,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2401",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Parafuso Allen"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 110,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1402",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Parafuso Philips"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 85,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2402",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Parafuso Philips"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 100,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1403",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Porca Travante"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 80,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2403",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Porca Travante"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 130,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1404",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Arruela de Pressão"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 95,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2404",
	Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Arruela de Pressão"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 140,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1405",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Parafuso M6"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 120,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2405",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Parafuso M6"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 130,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1406",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Parafuso M8"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 115,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2406",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Parafuso M8"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 120,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1407",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Parafuso M10"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 100,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2407",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Parafuso M10"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 150,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1408",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Porca M6"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 125,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2408",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Porca M6"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 145,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1409",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Porca M8"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 130,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2409",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Porca M8"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 160,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1410",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Arruela M6"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 140,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2410",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Arruela M6"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 155,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1411",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Arruela M8"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 145,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2411",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Arruela M8"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 150,
	Responsavel = "Setor de Compras",
	NotaFiscal = "NF-1412",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Arruela M10"],
	UsuarioId = usuarios["compras@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 138,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2412",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Arruela M10"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 40,
	Responsavel = "Recebimento",
	NotaFiscal = "NF-1413",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Fita Gomada"],
	UsuarioId = usuarios["producao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 28,
	Responsavel = "Expedição",
	NotaFiscal = "REQ-2413",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Fita Gomada"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 30,
	Responsavel = "Recebimento",
	NotaFiscal = "NF-1414",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Caixa Arquivo Morto"],
	UsuarioId = usuarios["producao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 20,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2414",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Caixa Arquivo Morto"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 35,
	Responsavel = "Recebimento",
	NotaFiscal = "NF-1415",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Envelope Bolha"],
	UsuarioId = usuarios["producao@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 24,
	Responsavel = "Expedição",
	NotaFiscal = "REQ-2415",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Envelope Bolha"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},

new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 25,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1501",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Bloco de Notas"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2501",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Bloco de Notas"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1502",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Post-it"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 12,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2502",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Post-it"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1503",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Envelope A4"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Financeiro",
	NotaFiscal = "REQ-2503",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Envelope A4"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1504",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Pasta Suspensa"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "RH",
	NotaFiscal = "REQ-2504",
	Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Pasta Suspensa"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 22,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1505",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Caderno Universitário"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2505",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Caderno Universitário"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1506",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Calculadora de Mesa"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Financeiro",
	NotaFiscal = "REQ-2506",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Calculadora de Mesa"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 30,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1507",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Clips Metálicos"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 18,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2507",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Clips Metálicos"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1508",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Grampo Trilho"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2508",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Grampo Trilho"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 14,
	Responsavel = "RH",
	NotaFiscal = "NF-1509",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Camisa Social Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2509",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Camisa Social Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "RH",
	NotaFiscal = "NF-1510",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Calça Brim Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2510",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Calça Brim Operacional"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "RH",
	NotaFiscal = "NF-1511",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Cinto Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2511",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Cinto Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "RH",
	NotaFiscal = "NF-1512",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Camiseta Polo Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2512",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Camiseta Polo Operacional"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "RH",
	NotaFiscal = "NF-1513",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Calça Jeans Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2513",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Calça Jeans Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "RH",
	NotaFiscal = "NF-1514",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Tesoura de Escritório"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 7,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2514",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Tesoura de Escritório"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1515",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Etiqueta Adesiva A4"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2515",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Etiqueta Adesiva A4"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},

new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 25,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1501",
	Data = DateTime.Now.AddDays(-35),
	ProdutoId = produtos["Bloco de Notas"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2501",
	Data = DateTime.Now.AddDays(-34),
	ProdutoId = produtos["Bloco de Notas"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1502",
	Data = DateTime.Now.AddDays(-33),
	ProdutoId = produtos["Post-it"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 12,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2502",
	Data = DateTime.Now.AddDays(-32),
	ProdutoId = produtos["Post-it"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1503",
	Data = DateTime.Now.AddDays(-31),
	ProdutoId = produtos["Envelope A4"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Financeiro",
	NotaFiscal = "REQ-2503",
	Data = DateTime.Now.AddDays(-30),
	ProdutoId = produtos["Envelope A4"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1504",
	Data = DateTime.Now.AddDays(-29),
	ProdutoId = produtos["Pasta Suspensa"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "RH",
	NotaFiscal = "REQ-2504",
	Data = DateTime.Now.AddDays(-28),
	ProdutoId = produtos["Pasta Suspensa"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 22,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1505",
	Data = DateTime.Now.AddDays(-27),
	ProdutoId = produtos["Caderno Universitário"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 14,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2505",
	Data = DateTime.Now.AddDays(-26),
	ProdutoId = produtos["Caderno Universitário"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1506",
	Data = DateTime.Now.AddDays(-25),
	ProdutoId = produtos["Calculadora de Mesa"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Financeiro",
	NotaFiscal = "REQ-2506",
	Data = DateTime.Now.AddDays(-24),
	ProdutoId = produtos["Calculadora de Mesa"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 30,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1507",
	Data = DateTime.Now.AddDays(-23),
	ProdutoId = produtos["Clips Metálicos"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 18,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2507",
	Data = DateTime.Now.AddDays(-22),
	ProdutoId = produtos["Clips Metálicos"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 20,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1508",
	Data = DateTime.Now.AddDays(-21),
	ProdutoId = produtos["Grampo Trilho"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2508",
	Data = DateTime.Now.AddDays(-20),
	ProdutoId = produtos["Grampo Trilho"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 14,
	Responsavel = "RH",
	NotaFiscal = "NF-1509",
	Data = DateTime.Now.AddDays(-19),
	ProdutoId = produtos["Camisa Social Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2509",
	Data = DateTime.Now.AddDays(-18),
	ProdutoId = produtos["Camisa Social Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "RH",
	NotaFiscal = "NF-1510",
	Data = DateTime.Now.AddDays(-17),
	ProdutoId = produtos["Calça Brim Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 10,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2510",
	Data = DateTime.Now.AddDays(-16),
	ProdutoId = produtos["Calça Brim Operacional"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 10,
	Responsavel = "RH",
	NotaFiscal = "NF-1511",
	Data = DateTime.Now.AddDays(-15),
	ProdutoId = produtos["Cinto Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 6,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2511",
	Data = DateTime.Now.AddDays(-14),
	ProdutoId = produtos["Cinto Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 18,
	Responsavel = "RH",
	NotaFiscal = "NF-1512",
	Data = DateTime.Now.AddDays(-13),
	ProdutoId = produtos["Camiseta Polo Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 11,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2512",
	Data = DateTime.Now.AddDays(-12),
	ProdutoId = produtos["Camiseta Polo Operacional"],
	UsuarioId = usuarios["almoxarife2@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 15,
	Responsavel = "RH",
	NotaFiscal = "NF-1513",
	Data = DateTime.Now.AddDays(-11),
	ProdutoId = produtos["Calça Jeans Operacional"],
	UsuarioId = usuarios["rh@driveline.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Produção",
	NotaFiscal = "REQ-2513",
	Data = DateTime.Now.AddDays(-10),
	ProdutoId = produtos["Calça Jeans Operacional"],
	UsuarioId = usuarios["almoxarife1@driveline.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 12,
	Responsavel = "RH",
	NotaFiscal = "NF-1514",
	Data = DateTime.Now.AddDays(-9),
	ProdutoId = produtos["Tesoura de Escritório"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 7,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2514",
	Data = DateTime.Now.AddDays(-8),
	ProdutoId = produtos["Tesoura de Escritório"],
	UsuarioId = usuarios["usuario@nexstock.com"]
},
new Movimentacao
{
	Tipo = "entrada",
	Quantidade = 16,
	Responsavel = "Setor Administrativo",
	NotaFiscal = "NF-1515",
	Data = DateTime.Now.AddDays(-7),
	ProdutoId = produtos["Etiqueta Adesiva A4"],
	UsuarioId = usuarios["admin@nexstock.com"]
},
new Movimentacao
{
	Tipo = "saida",
	Quantidade = 9,
	Responsavel = "Administrativo",
	NotaFiscal = "REQ-2515",
	Data = DateTime.Now.AddDays(-6),
	ProdutoId = produtos["Etiqueta Adesiva A4"],
	UsuarioId = usuarios["usuario@nexstock.com"]
}




		};

		foreach (var mov in movimentacoes)
		{
			var existe = await db.Movimentacoes.AnyAsync(m =>
				m.NotaFiscal == mov.NotaFiscal &&
				m.ProdutoId == mov.ProdutoId &&
				m.Tipo == mov.Tipo);

			if (!existe)
				db.Movimentacoes.Add(mov);
		}

		await db.SaveChangesAsync();



		//db.Movimentacoes.AddRange(movimentacoes);

		//await db.SaveChangesAsync();


	}

	private static string GerarHash(string texto)
	{
		var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
		return Convert.ToHexString(bytes).ToLower();
	}
}