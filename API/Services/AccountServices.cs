using API.DataAccess.UnitOfWork;
using API.Services.Registration;
using API.Services.Token;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace API.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AccountServices(
            IUnitOfWork unitOfWork,
            IConfiguration config,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _mapper = mapper;
        }

        public ITokenService Token => new TokenService(_config, _unitOfWork.UserRepository);
        public IRegistrationService Registration => new RegistrationService(_unitOfWork.UserRepository, _mapper);

    }
}