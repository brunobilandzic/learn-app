using System.Threading.Tasks;
using API.DataAccess.Repositories.User;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UnitOfWork(
            LearnAppDbContext context,
            UserManager<AppUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;
        }

        public IUserRepository UserRepository => new UserRepository(_userManager, _context);
        public Task<int> SaveAllChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}