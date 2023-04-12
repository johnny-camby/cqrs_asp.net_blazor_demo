using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer
{
    public static class DataLayerServicesRegistration 
    {        
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<CqrsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CustomerOrderDbConn"),
                m => m.MigrationsAssembly("DataLayer"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IDataRepository<Customer>, CustomerRepository>();
            services.AddScoped<IDataRepository<FullAddress>, FullAddressRepository>();

            return services;
        }
    }
}
 