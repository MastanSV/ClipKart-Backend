using Clipkart.Infrastructure.Repository;
using ClipKart.Core.Helpers.Common;
using ClipKart.Core.Helpers.UserLogin;
using ClipKart.Core.Interfaces.Common;
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Services;

namespace ClipKart.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserLoginCrendentialValidator, UserLoginCredentialsValidator>();
            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();

            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
