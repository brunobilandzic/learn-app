using System.Threading.Tasks;
using API.DataAccess.Repositories.User;

namespace API.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        Task<int> SaveAllChanges();
    }
}