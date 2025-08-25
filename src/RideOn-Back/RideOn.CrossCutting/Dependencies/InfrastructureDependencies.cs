using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideOn.Infrastructure.Context;

namespace RideOn.CrossCutting.Dependencies;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        var connection_string = configuration.GetConnectionString("postgress");

        services.AddDbContext<RideOnDbContext>(options =>
        {
            options.UseNpgsql(connection_string)
                .ConfigureLoggingCacheTime(TimeSpan.FromSeconds(1))
                .EnableDetailedErrors(detailedErrorsEnabled: true)
                .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
        });

        return services;
    }
}

