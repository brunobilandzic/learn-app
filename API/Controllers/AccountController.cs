using System.Threading.Tasks;
using API.Services;
using API.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IServicesIndex services) : base(services)
        {
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthorizedDto>> Login(LoginDto loginDto)
        {
            var authorizedDto = await _services.Token.AuthorizeUser(loginDto);

            return Ok(authorizedDto);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthorizedDto>> Register(RegisterDto registerDto)
        {
            var newUser =  await _services.Registration.Register(registerDto);

            return Ok(
                new AuthorizedDto
                {
                    Username = registerDto.Username,
                    Token = _services.Token.CreateToken(newUser)
                }
            );
        }


    }
}