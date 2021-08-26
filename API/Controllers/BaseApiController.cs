using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IServicesIndex _services;

        public BaseApiController(IServicesIndex services)
        {
            _services = services;
        }
    }
}