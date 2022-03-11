using Business.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class BusinessExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<TokenHelper>();
            services.AddTransient<BookingPriceCalculatorHelper>();
        }
    }
}