using API.DataLayer.Entities.Identity;
using API.Services.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}