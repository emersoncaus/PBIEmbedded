using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Persistence.Interface
{
    public interface IDashboardPersist
    {
         Task<Dashboard> GetDashboardByIdAsync(int dashboardId);
         Task<Dashboard[]> GetAllDashboardsAsync();
        //  Task<Dashboard[]> GetDashboardsByAreaAsync(string area);
         Task<Dashboard[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalID);

    }
}