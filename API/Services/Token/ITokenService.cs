using System.Threading.Tasks;
using API.DataLayer.Entities.Identity;
using API.DTOs;


namespace API.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        Task<AuthorizedDto>  AuthorizeUser(LoginDto loginDto);
    }
}