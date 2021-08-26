using System.Threading.Tasks;
using API.DataAccess.Queries;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Identity;
using API.Services.DTOs;
using Microsoft.AspNetCore.Identity;

namespace API.DataAccess.Repositories.User
{
    

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly LearnAppDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, LearnAppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            
        }

        public async Task<AppUser> GetUser(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> AddUser(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}