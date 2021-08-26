using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.DTOs;

namespace API.DataAccess.Repositories.Learning
{
    public interface ICoursesRepository
    {
        Task<CourseDto> AddNewCourse(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetCourses();
    }
}