using AdvFullstack_Labb1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Data
{
    public class MyCafeLabb1Context : DbContext
    {
        public MyCafeLabb1Context(DbContextOptions<MyCafeLabb1Context> options) : base(options)
        {
            
        }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
