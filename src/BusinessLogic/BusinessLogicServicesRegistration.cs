﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class BusinessLogicServicesRegistration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

    }
}
