using System.Threading.Tasks;
using API.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.DataAccess.Repositories.User
{
    public interface IUserRepository
    {
        Task<AppUser> GetUser(string username);
        Task<bool> CheckPassword(AppUser user, string password);
        Task<IdentityResult> AddUser(AppUser user, string password);
    }
}