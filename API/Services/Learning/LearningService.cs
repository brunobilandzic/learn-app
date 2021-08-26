using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.Services.DTOs;
using AutoMapper;

namespace API.Services.Learning
{
    public class LearningService : ILearningService
    {
        /****************************
            Better whole unit of work
        Than multiple repos
        ****************************/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LearningService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDto> AddNewCourse(CourseDto courseDto)
        {
            return await _unitOfWork.CoursesRepository.AddNewCourse(courseDto);
        }

        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            return await _unitOfWork.CoursesRepository.GetCourses();
        }


    }   
}