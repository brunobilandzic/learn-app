using API.DataAccess.UnitOfWork;
using API.DataLayer.EfCode.DbSetup;
using API.Helpers;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configuration
{
    public static class AddServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<LearnAppDbContext>(options => 
                {options.UseSqlite(config.GetConnectionString("DefaultConnection"));}
            );
            
            
        

            return services;
        }
    }
}