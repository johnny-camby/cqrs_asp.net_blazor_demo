using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace DataLayer
{
    public static class DataLayerServiceRegistration
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
