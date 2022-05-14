using Api.Database;
using Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class IoC
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}
