using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;
using PBIEmbedded.Persistence.Contexts;

namespace PBIEmbedded.Persistence
{
    public class UserPersist : IUserPersist
    {
        private readonly PBIEmbeddedContext _context;
        public UserPersist(PBIEmbeddedContext context)
        {
            this._context = context;

        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query.Where(u => u.Id.Equals(userId));
            
            return await query.FirstOrDefaultAsync();
        }
        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users;

            return await query.ToArrayAsync();
        }
    }
}