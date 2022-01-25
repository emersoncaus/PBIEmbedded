using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;
using PBIEmbedded.Persistence.Contexts;

namespace PBIEmbedded.Persistence
{
    public class ServicePrincipalPersist : IServicePrincipalPersist
    {
        private readonly PBIEmbeddedContext _context;
        public ServicePrincipalPersist(PBIEmbeddedContext context)
        {
            this._context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<ServicePrincipal> GetServicePrincipalByIdAsync(int servicePrincipalId, bool includeUsers = false)
        {
            IQueryable<ServicePrincipal> query = _context.ServicePrincipals;

            if(includeUsers)
            {
                // query = query.Include(sp => sp.Users);
            }

            query = query.Where(sp => sp.Id.Equals(servicePrincipalId));
            
            return await query.FirstOrDefaultAsync();;
        }
        public async Task<ServicePrincipal[]> GetAllServicePrincipalsAsync(bool includeUsers)
        {
            IQueryable<ServicePrincipal> query = _context.ServicePrincipals;

            if(includeUsers)
            {
                // query = query.Include(sp => sp.Users);
            }
            return await query.ToArrayAsync();
        }

        public async Task<ServicePrincipal[]> GetAllServicePrincipalsByUser(string userEmail)
        {
            IQueryable<ServicePrincipal> query = _context.ServicePrincipals;
            // query = query.Include(sp => sp.Users);
            // query = query.Where(sp => sp.Users.Where(u => u.Email.ToLower().Equals(userEmail.ToLower())) != null);

            return await query.ToArrayAsync();

        }
    }
}