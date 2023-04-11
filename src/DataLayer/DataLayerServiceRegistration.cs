using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer
{
    public static class DataLayerServiceRegistration 
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());   
            
            return services;
        }

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MainDbConnStr"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IDataRepository<Customer>, CustomerRepository>();
            services.AddScoped<IDataRepository<FullAddress>, FullAddressRepository>();

            return services;
        }
    }
}
 