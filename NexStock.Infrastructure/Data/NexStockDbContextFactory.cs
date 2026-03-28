using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NexStock.Infrastructure.Data;

public class NexStockDbContextFactory : IDesignTimeDbContextFactory<NexStockDbContext>

{

	public NexStockDbContext CreateDbContext(string[] args)

	{

		var optionsBuilder = new DbContextOptionsBuilder<NexStockDbContext>();

		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NexStockDb;Trusted_Connection=True;");

		return new NexStockDbContext(optionsBuilder.Options);

	}

}

