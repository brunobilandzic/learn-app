using System.Net;
using System.Threading.Tasks;
using API.DataAccess.Repositories.User;
using API.DataLayer.Entities.Identity;
using API.Errors;
using API.Services.DTOs;
using AutoMapper;

namespace API.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegistrationService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AppUser> Register(RegisterDto registerDto)
        {
            if(await _userRepository.GetUser(registerDto.Username) != null) 
                throw new AppException(
                    HttpStatusCode.BadRequest, 
                    $"User with ${registerDto.Username} already exists"
                    );
            
            var newUser = _mapper.Map<AppUser>(registerDto);

            var result = await _userRepository.AddUser(newUser, registerDto.Password);

            if(result == null)
                throw new AppException(
                    HttpStatusCode.InternalServerError,
                    "Something went wrong while creating new user"
                );
            
            return newUser;
        }
    }
}