using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseApp.Application.Interfaces;
using WarehouseApp.Infrastructure.Persistence;
using WarehouseApp.Infrastructure.Repositories;

namespace WarehouseApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
