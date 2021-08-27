using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.Services;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CoursesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _unitOfWork.CoursesRepository.GetCourses();
            return Ok(courses);
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
        {
            var newCourse = await _unitOfWork.CoursesRepository.AddNewCourse(courseDto);

            return Ok(newCourse);
        }


    }
}