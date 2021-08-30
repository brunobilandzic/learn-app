using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess.Queries;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using API.DTOs;
using API.Errors;
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

        public async Task<IEnumerable<CourseDto>> GetUserCourses(int userId)
        {
            var coursesIds = await _context.StudentCourses
                .Where(sc => sc.StudentId == userId)
                .Select(sc => sc.CourseId)
                .ToListAsync();
            
            var courses = await _context.Courses
                .Where(c => coursesIds.Contains(c.CourseId))
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return courses;
        }

        public async Task AddStudentCourse(int courseId, int studentId)
        {
            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _context.StudentCourses
                .AddAsync(studentCourse);

            var examIds = await _context.Exams
                .Where(e => e.CourseId == courseId)
                .Select(e => e.ExamId)
                .ToListAsync();

            foreach (var examId in examIds )
            {
                await _context.StudentExams
                    .AddAsync(new StudentExam {
                        StudentId = studentId,
                        ExamId = examId
                    });
            }
            
            if(await _context.SaveChangesAsync() <= 0) throw new InternalServerException("Failed to add student to course.");
        }

        public async Task RemoveStudentCourse(int courseId, int studentId)
        {
            var examIds = await _context.Exams
                .Where(e => e.CourseId == courseId)
                .Select(e => e.ExamId)
                .ToListAsync();

            foreach (var examId in examIds )
            {
                var studentExam = new StudentExam {
                        StudentId = studentId,
                        ExamId = examId
                    };
                _context.StudentExams.Attach(studentExam);
                _context.StudentExams
                    .Remove(studentExam);
            }
            var lectureIds = await _context.Lectures
                .Where(l => l.CourseId == courseId)
                .Select(l => l.LectureId)
                .ToListAsync();

            var lectureLearningTasksToDelete = await _context.LearningTasks
                .Include(lt => lt.LectureLearningTasks)
                .Where(lt => lt.StudentId == studentId)
                .SelectMany(lt => lt.LectureLearningTasks)
                .Where(llt => lectureIds.Contains(llt.LectureId))
                .ToListAsync();
                
            _context.LectureLearningTasks.RemoveRange(lectureLearningTasksToDelete);

            var studentCourse = new StudentCourse{
                StudentId = studentId, 
                CourseId = courseId
            };
            _context.StudentCourses.Attach(studentCourse);
            _context.Remove(studentCourse);
            
            if(await _context.SaveChangesAsync() <= 0) throw new InternalServerException("Failed to remove student from course."); 
        }
    }
}