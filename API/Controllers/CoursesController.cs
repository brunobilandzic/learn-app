using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.Services;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Services.ClaimsExtensions;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.AspNetCore.Authorization;
using API.Errors;

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

        [Authorize]
        [HttpPost("enroll/{courseId}")]
        public async Task<ActionResult> AddStudentCourse(int courseId)
        {
            await _unitOfWork.CoursesRepository.AddStudentCourse(courseId, User.GetUserId());
            return Ok();
        }

        [Authorize]
        [HttpPost("unroll/{courseId}")]
        public async Task<ActionResult> RemoveStudentCourse(int courseId)
        {
            await _unitOfWork.CoursesRepository.RemoveStudentCourse(courseId, User.GetUserId());
            return Ok();
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _unitOfWork.CoursesRepository.GetCourses();

            return Ok(courses);
        }
        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseNavigationDto>> GetCourse(int courseId)
        {
            var course = await _unitOfWork.CoursesRepository.GetCourse(courseId);

            return Ok(course);
        }

        [HttpGet("student")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCoursesForStudent()
        {
            var courses = await _unitOfWork.CoursesRepository.GetUserCourses(User.GetUserId());

            return Ok(courses);
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse(CourseDto courseDto)
        {
            var newCourse = await _unitOfWork.CoursesRepository.AddNewCourse(courseDto);

            return Ok(newCourse);
        }



        [HttpPost("exams")]
        public async Task<ActionResult<ExamDto>> AddExam(ExamDto examDto)
        {
            var newExam = await _unitOfWork.ExamsRepository.AddExam(examDto);
            
            return Ok(newExam);
        }

        [HttpPost("lectures")]
        public async Task<ActionResult<ExamDto>> AddLecture(LectureDto lectureDto)
        {
            var newLecture = await _unitOfWork.LecturesRepository.AddLecture(lectureDto);
            
            return Ok(newLecture);
        }


        [HttpGet("student/{courseId}")]
        public async Task<ActionResult<StudentCourseDto>> GetStudentCourse(int courseId)
        {
            return Ok(await _unitOfWork.CoursesRepository
                .GetStudentCourse(courseId, User.GetUserId()));
            
        }
        


    }
}