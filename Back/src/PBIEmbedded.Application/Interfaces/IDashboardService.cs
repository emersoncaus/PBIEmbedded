using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Interfaces
{
    public interface IDashboardService
    {
         Task<Dashboard> AddDashboard (Dashboard model);
         Task<Dashboard> UpdateDashboard (int dashboardId, Dashboard model);
         Task<bool> DeleteDashboard (int dashboardId);
         Task<Dashboard[]> GetAllDashboardsAsync();
         Task<Dashboard> GetDashboardByIdAsync(int DashboardId);
        //  Task<Dashboard[]> GetDashboardsByAreaAsync(string Area);
         Task<Dashboard[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalId);
    }
}