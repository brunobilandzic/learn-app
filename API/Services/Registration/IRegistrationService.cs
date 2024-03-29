using System.Threading.Tasks;
using API.DataLayer.Entities.Identity;
using API.DTOs;

namespace API.Services.Registration
{
    public interface IRegistrationService
    {
        Task<AppUser> Register(RegisterDto registerDto);
        
    }
}