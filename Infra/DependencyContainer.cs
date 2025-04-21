using Application.Services;
using Application.Services.Interfaces;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<ITestEntityRepository, TestEntityRepository>();
            services.AddScoped<ITestEntityService, TestEntityService>();


            services.AddScoped<IAstronautRepository, AstronautRepository>();
            services.AddScoped<IAstronautService, AstronautService>();

            services.AddScoped<ISatelliteRepository, SatelliteRepository>();
            services.AddScoped<ISatelliteService, SatelliteService>();
            


        }
    }
}
