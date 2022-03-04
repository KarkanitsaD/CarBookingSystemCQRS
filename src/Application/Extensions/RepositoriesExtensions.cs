using DAL.Repositories;
using DAL.Repositories.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingPointRepository, BookingPointRepository>();
        }
    }
}