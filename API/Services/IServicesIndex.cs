using API.Services.Learning;
using API.Services.Registration;
using API.Services.Token;

namespace API.Services
{
    public interface IServicesIndex
    {
        ITokenService Token { get; }
        IRegistrationService Registration { get; }
        ILearningService LearningService {get;}

    }
}