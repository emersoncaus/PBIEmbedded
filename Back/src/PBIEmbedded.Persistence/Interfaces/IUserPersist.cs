using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Persistence.Interface
{
    public interface IUserPersist
    {
         Task<User> GetUserByIdAsync(int UserId);
         Task<User[]> GetAllUsersAsync();
    }
}