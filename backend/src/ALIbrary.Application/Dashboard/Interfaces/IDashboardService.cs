using ALIbrary.Application.Dashboard.DTOs;

namespace ALIbrary.Application.Dashboard.Interfaces;

public interface IDashboardService
{
    Task<DashboardResponse> GetDashboardAsync();
}