using AdvFullstack_Labb1.Models;
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
        public DbSet<TableBooking> TableBookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableBooking>().
                HasKey(tb => new { tb.TableId, tb.BookingId });

            modelBuilder.Entity<TableBooking>()
                .HasOne(tb => tb.Table)
                .WithMany(t => t.TableBookings)
                .HasForeignKey(tb => tb.TableId);

            modelBuilder.Entity<TableBooking>()
                .HasOne(tb => tb.Booking)
                .WithMany(b => b.TableBookings)
                .HasForeignKey(tb => tb.BookingId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
