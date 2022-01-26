using System.Threading.Tasks;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Interfaces
{
    public interface IDashboardService
    {
         Task<DashboardDto> AddDashboard (DashboardDto model);
         Task<DashboardDto> UpdateDashboard (int dashboardId, DashboardDto model);
         Task<bool> DeleteDashboard (int dashboardId);
         Task<DashboardDto[]> GetAllDashboardsAsync();
         Task<DashboardDto> GetDashboardByIdAsync(int DashboardId);
        //  Task<Dashboard[]> GetDashboardsByAreaAsync(string Area);
         Task<DashboardDto[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalId);
    }
}