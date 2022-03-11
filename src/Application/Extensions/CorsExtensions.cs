using Application.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsOptions.ApiCorsName,
                    builder =>
                    {
                        builder.WithOrigins(CorsOptions.WebApp)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            return services;
        }
    }
}