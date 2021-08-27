using API.DataLayer.Entities.Identity;
using API.DataLayer.Entities.Learning;
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
        }
    }
}