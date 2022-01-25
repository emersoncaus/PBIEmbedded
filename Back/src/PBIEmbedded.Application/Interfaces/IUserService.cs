using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Interfaces
{
    public interface IUserService
    {
         Task<User> AddUser (User model);
         Task<User> UpdateUser (int userId, User model);
         Task<bool> DeleteUser (int userId);
         Task<User[]> GetAllUsersAsync();
         Task<User> GetUserByIdAsync(int UserId);

    }
}