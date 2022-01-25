using System.Threading.Tasks;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.Application
{
    public class UserService : IUserService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IUserPersist _userPersist;
        public UserService(IGeneralPersist generalPersist, IUserPersist userPersist)
        {
            this._userPersist = userPersist;
            this._generalPersist = generalPersist;

        }
        public Task<User> AddUser(User model)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateUser(int userId, User model)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User[]> GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int UserId)
        {
            throw new System.NotImplementedException();
        }

    }
}