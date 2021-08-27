using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.Services;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Services.ClaimsExtensions;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.AspNetCore.Authorization;

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
            return Ok("Student Enrolled");
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

        [HttpGet("exams/{courseId}")]
        public async Task<ActionResult<ExamDto>> GetExamsForCourse(int courseId)
        {
            var newExam = await _unitOfWork.ExamsRepository.GetExams(courseId);
            
            return Ok(newExam);
        }


        [HttpPost("exams")]
        public async Task<ActionResult<ExamDto>> AddExam(ExamDto examDto)
        {
            var newExam = await _unitOfWork.ExamsRepository.AddExam(examDto);
            
            return Ok(newExam);
        }

        [HttpGet("lectures/{courseId}")]
        public async Task<ActionResult<LectureDto>> GetLecturesForCourse(int courseId)
        {
            var lectures = await _unitOfWork.LecturesRepository.GetLectures(courseId);
            
            return Ok(lectures);
        }


        [HttpPost("lectures")]
        public async Task<ActionResult<ExamDto>> AddLecture(LectureDto lectureDto)
        {
            var newLecture = await _unitOfWork.LecturesRepository.AddLecture(lectureDto);
            
            return Ok(newLecture);
        }
        


    }
}