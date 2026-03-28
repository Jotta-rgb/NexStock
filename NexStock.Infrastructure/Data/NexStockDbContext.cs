using Microsoft.EntityFrameworkCore;
using NexStock.Domain.Entities;

namespace NexStock.Infrastructure.Data;

public class NexStockDbContext : DbContext
{
	public NexStockDbContext(DbContextOptions<NexStockDbContext> options) : base(options)
	{
	}
	public DbSet<Usuario> Usuarios { get; set; }
	public DbSet<Produto> Produtos { get; set; }
	public DbSet<Movimentacao> Movimentacoes { get; set; }
	public DbSet<Categoria> Categorias { get; set; }
	public DbSet<Localizacao> Localizacoes { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Usuario>(entity =>
		{
			entity.HasKey(u => u.Id);
			entity.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(150);
			entity.Property(u => u.SenhaHash)
				.IsRequired()
				.HasMaxLength(200);
			entity.HasIndex(u => u.Email).IsUnique();
		});
		modelBuilder.Entity<Categoria>(entity =>
		{
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(100);
			entity.HasIndex(c => c.Nome).IsUnique();
		});
		modelBuilder.Entity<Localizacao>(entity =>
		{
			entity.HasKey(l => l.Id);
			entity.Property(l => l.Nome)
				.IsRequired()
				.HasMaxLength(100);
			entity.HasIndex(l => l.Nome).IsUnique();
		});
		modelBuilder.Entity<Produto>(entity =>
		{
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Nome)
				.IsRequired()
				.HasMaxLength(150);
			entity.Property(p => p.Unidade)
				.IsRequired()
				.HasMaxLength(50);
			entity.Property(p => p.Quantidade)
				.IsRequired();
			entity.Property(p => p.EstoqueMinimo)
				.IsRequired();
			entity.HasOne(p => p.Categoria)
				.WithMany(c => c.Produtos)
				.HasForeignKey(p => p.CategoriaId)
				.OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(p => p.Localizacao)
				.WithMany(l => l.Produtos)
				.HasForeignKey(p => p.LocalizacaoId)
				.OnDelete(DeleteBehavior.Restrict);
		});
		modelBuilder.Entity<Movimentacao>(entity =>
		{
			entity.HasKey(m => m.Id);
			entity.Property(m => m.Tipo)
				.IsRequired()
				.HasMaxLength(20);
			entity.Property(m => m.Quantidade)
				.IsRequired();
			entity.Property(m => m.Responsavel)
				.IsRequired()
				.HasMaxLength(100);
			entity.Property(m => m.NotaFiscal)
				.HasMaxLength(100);
			entity.Property(m => m.Data)
				.IsRequired();
			entity.HasOne(m => m.Produto)
				.WithMany(p => p.Movimentacoes)
				.HasForeignKey(m => m.ProdutoId)
				.OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(m => m.Usuario)
				.WithMany(u => u.Movimentacoes)
				.HasForeignKey(m => m.UsuarioId)
				.OnDelete(DeleteBehavior.Restrict);
		});
	}
}

