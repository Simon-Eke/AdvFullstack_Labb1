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

            var adminsToSeed = new List<(string Username, string PlainPassword)>
            {
                ("SimonEkeAdmin2", "SuperSecure69!")
            };

            foreach (var (username, password) in adminsToSeed)
            {
                var existingAdmin = await db.Admins.FirstOrDefaultAsync(a => a.Username == username);

                if (existingAdmin == null)
                {
                    var admin = new Admin
                    {
                        Username = username,
                        PasswordHash = hasher.HashPassword(password)
                    };

                    db.Admins.Add(admin);
                    Console.WriteLine($"Seeded admin: {username}");
                }
                else
                {
                    Console.WriteLine($"Admin '{username}' already exists");
                }
            }

            await db.SaveChangesAsync();
        }
    }
}
