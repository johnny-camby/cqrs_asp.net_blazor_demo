﻿using BusinessLogic;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BlazorCQRS.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddBusinessLogicServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OpenCQRS", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }
               
        public static WebApplication ConfigurePipeline(this WebApplication app) 
        {
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(s => 
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor-CQRS API");
                });
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.MapControllers();

            return app;
        }

        public static async Task ConfigureDatabaseAsync(this WebApplication app) 
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var ctx = scope.ServiceProvider.GetService<CqrsDbContext>();

                if(ctx != null)
                {
                    await ctx.Database.EnsureDeletedAsync();
                    await ctx.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // logging
            }
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s => 
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Blazor-CQRS API",

                });
            });
        }

    }
}
