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
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarImageRepository, CarImageRepository>();
            services.AddScoped<ICarCarImageRepository, CarCarImageRepository>();
            services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();
        }
    }
}