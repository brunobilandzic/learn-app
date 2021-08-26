using API.Services.Registration;
using API.Services.Token;

namespace API.Services
{
    public interface IServicesIndex
    {
        ITokenService Token { get; }
        IRegistrationService Registration { get; }
    }
}