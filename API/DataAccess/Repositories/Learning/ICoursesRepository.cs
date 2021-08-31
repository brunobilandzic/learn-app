using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.DataAccess.Repositories.Learning
{
    public interface ICoursesRepository
    {
        Task<CourseNavigationDto> GetCourse(int courseId);
        Task<CourseDto> AddNewCourse(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetCourses();

        Task AddStudentCourse(int courseId, int studentId);
        Task RemoveStudentCourse(int courseId, int studentId);
        Task<IEnumerable<CourseDto>> GetUserCourses(int userId);
    }
}