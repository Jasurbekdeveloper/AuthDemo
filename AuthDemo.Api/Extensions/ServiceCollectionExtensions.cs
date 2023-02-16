using AuthDemo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace AuthDemo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectingString");


            services.AddDbContextPool<AuthDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                });
            });
            return services;
        }
    }
}
