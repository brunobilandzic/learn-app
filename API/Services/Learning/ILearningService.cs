using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.DTOs;

namespace API.Services.Learning
{
    public interface ILearningService
    {
        Task<CourseDto> AddNewCourse(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetCourses();
    }
}