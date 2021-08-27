using API.DataLayer.Entities.Identity;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using API.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Exam, ExamDto>();
            CreateMap<LectureDto, Lecture>();
            CreateMap<Lecture, LectureDto>();
            CreateMap<StudentCourseDto, StudentCourse>();
            CreateMap<StudentCourse, StudentCourseDto>();
        }
    }
}