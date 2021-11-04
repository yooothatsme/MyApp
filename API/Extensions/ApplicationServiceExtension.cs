using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDbContext<DataContext>(options =>
               {
                   options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
               });
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

    }
}