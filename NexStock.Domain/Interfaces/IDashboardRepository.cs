using NexStock.Domain.Entities;

namespace NexStock.Domain.Interfaces;

public interface IDashboardRepository
{
	Task<Dashboard?> ObterResumoAsync();
}

