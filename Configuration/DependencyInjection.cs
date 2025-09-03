using AdvFullstack_Labb1.Repositories;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services;
using AdvFullstack_Labb1.Services.IServices;
using AdvFullstack_Labb1.Services.Shared;
using Microsoft.Extensions.Configuration;

namespace AdvFullstack_Labb1.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<PasswordHasher>();

            return services;
        }
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();

            return services;
        }
    }
}
