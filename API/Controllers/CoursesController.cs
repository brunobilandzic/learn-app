using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using API.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CoursesController : BaseApiController
    {
        public CoursesController(IServicesIndex services) : base(services)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _services.LearningService.GetCourses();
            return Ok(courses);
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
        {
            var newCourse = await _services.LearningService.AddNewCourse(courseDto);

            return Ok(newCourse);
        }
    }
}