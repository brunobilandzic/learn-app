using System.Threading.Tasks;
using API.DataAccess.Repositories.Learning;
using API.DataAccess.Repositories.User;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UnitOfWork(
            LearnAppDbContext context,
            UserManager<AppUser> userManager,
            IMapper mapper
            )
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_userManager, _context);

        public ICoursesRepository CoursesRepository => new CoursesRepository(_context, _mapper);

        public IExamsRepository ExamsRepository => new ExamsRepository();
        public ILecturesRepository LecturesRepository => new LecturesRepository();

        public ILearningTasksRepository LearningTasksRepository => new LearningTasksRepository();
        public Task<int> SaveAllChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}