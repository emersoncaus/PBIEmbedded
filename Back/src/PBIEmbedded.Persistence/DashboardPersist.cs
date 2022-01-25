using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;
using PBIEmbedded.Persistence.Contexts;

namespace PBIEmbedded.Persistence
{
    public class DashboardPersist : IDashboardPersist
    {
        private readonly PBIEmbeddedContext _context;
        public DashboardPersist(PBIEmbeddedContext context)
        {
            this._context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<Dashboard> GetDashboardByIdAsync(int dashboardId)
        {
            IQueryable<Dashboard> query = _context.Dashboards;

            query = query.Where(d => d.Id.Equals(dashboardId));
            
            return await query.FirstOrDefaultAsync();;
        }
        public async Task<Dashboard[]> GetAllDashboardsAsync()
        {
            IQueryable<Dashboard> query = _context.Dashboards;

            return await query.ToArrayAsync();
        }
        // public async Task<Dashboard[]> GetDashboardsByAreaAsync(string area)
        // {
        //     IQueryable<Dashboard> query = _context.Dashboards;
        //     query = query.Where(d => d.Area.ToLower().Contains(area.ToLower()));

        //     return await query.ToArrayAsync();
        // }

        public async Task<Dashboard[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalId)
        {
            IQueryable<Dashboard> query = _context.Dashboards;

            query = query.Include(d => d.DashboardServicePrincipals.Where(dsp => dsp.ServicePrincipalId.Equals(servicePrincipalId)));

            return await query.ToArrayAsync();
        }
    }
}