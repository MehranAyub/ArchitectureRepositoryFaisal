using AutoMapper;
using Core.Application;
using Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContext>(options =>
             options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
         
        }
    }
}
