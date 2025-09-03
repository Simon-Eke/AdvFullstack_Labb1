using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Configuration
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MyCafeLabb1Context>();
            var hasher = scope.ServiceProvider.GetRequiredService<PasswordHasher>();

            if (!await db.Admins.AnyAsync())
            {
                var admin = new Admin
                {
                    Username = "SimonEkeAdmin",
                    PasswordHash = hasher.HashPassword("SuperSecure69")
                };

                db.Admins.Add(admin);
                await db.SaveChangesAsync();

                Console.WriteLine("Admin user seeded");
            }
            else
            {
                Console.WriteLine("Admin user already exists");
            }
        }
    }
}
