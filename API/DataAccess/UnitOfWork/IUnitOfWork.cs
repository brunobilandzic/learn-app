using System.Threading.Tasks;
using API.DataAccess.Repositories.Learning;
using API.DataAccess.Repositories.User;

namespace API.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        ICoursesRepository CoursesRepository {get;}
        IExamsRepository ExamsRepository {get;}
        ILecturesRepository LecturesRepository {get;}
        ILearningTasksRepository LearningTasksRepository {get;}
        Task<int> SaveAllChanges();
    }
}