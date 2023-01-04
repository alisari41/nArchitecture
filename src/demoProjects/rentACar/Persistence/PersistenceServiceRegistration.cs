using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarCampConnectionString"))); // Projenin Adı Sonrasında ConnectionString

            services.AddScoped<IBrandRepository, BrandRepository>(); // Eğer Biri IBrandRepository isterse ona BrandRepository ver 
            services.AddScoped<IModelRepository, ModelRepository>(); 

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOprationClaimRepository,OprationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository,UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();

            return services;
        }
    }
}
