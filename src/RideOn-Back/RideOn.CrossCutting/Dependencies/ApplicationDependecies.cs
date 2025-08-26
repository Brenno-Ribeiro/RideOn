using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideOn.Application.Abstrations.Services;
using RideOn.Application.Automapper;

namespace RideOn.CrossCutting.Dependencies;

public static class ApplicationDependecies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMotocycleService, MotorcycleService>();

        services.AddAutoMapper(typeof(RideOnMapper));

        return services;
    }
}
