using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.Queries;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Learning;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories.Learning
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly LearnAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericQueries<Course> _queries;
        public CoursesRepository(
            LearnAppDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
            _queries = new GenericQueries<Course>(_context);
        }

        public async Task<CourseDto> AddNewCourse(CourseDto courseDto)
        {
            var newCourse = _mapper.Map<Course>(courseDto);

            await _context.AddAsync(newCourse);

            await _context.SaveChangesAsync(); // now courseId gets populated

            return _mapper.Map<CourseDto>(newCourse);
        }
        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            return await _queries.GetAll<CourseDto>(_mapper.ConfigurationProvider);
        }
    
    }
}