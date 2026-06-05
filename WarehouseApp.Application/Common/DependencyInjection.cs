
using Microsoft.Extensions.DependencyInjection;

namespace WarehouseApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // بعداً: UseCases / MediatR / Validators / AutoMapper اینجا
            return services;
        }
    }
}
