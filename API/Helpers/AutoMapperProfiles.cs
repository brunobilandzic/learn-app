using System.Linq;
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
            CreateMap<Course, CourseNavigationDto>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Exam, ExamDto>();
            CreateMap<LectureDto, Lecture>();
            CreateMap<Lecture, LectureDto>();
            CreateMap<StudentCourseDto, StudentCourse>();
            CreateMap<StudentCourse, StudentCourseDto>();
            CreateMap<LectureLearningTask, LectureLearningTaskDto>()
                .ForMember(
                    dest => dest.Topic,
                    opt => opt.MapFrom(
                        src => src.Lecture.Topic
                    )
                );
            CreateMap<LearningTaskDto, LearningTask>();
            CreateMap<LearningTask, LearningTaskDto>()
                .ForMember(
                    lt => lt.Lectures,
                    opt => opt.MapFrom(
                        src => src.LectureLearningTasks
                    )
                );
        }
    }
}