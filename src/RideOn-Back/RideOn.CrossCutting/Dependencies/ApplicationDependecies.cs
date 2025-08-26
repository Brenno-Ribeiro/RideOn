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
        services.AddScoped<IDeliveryManService, DeliveryManService>();
        services.AddScoped<IRentalService, RentalService>();

        services.AddAutoMapper(typeof(RideOnMapper));

        return services;
    }
}
