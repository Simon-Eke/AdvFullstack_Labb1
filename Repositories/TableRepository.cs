using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Repositories
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(MyCafeLabb1Context context) : base(context) { }

        public async Task<List<Table>> GetAvailableTablesAsync(int wantedSeats, DateTime desiredStartTime)
        {
            var desiredEndTime = desiredStartTime.AddHours(2);

            var availableTables = await _context.Tables
                .Where(t => t.Seatings >= wantedSeats)
                .Where(t => t.Bookings.All(b =>
                    b.StartTime >= desiredEndTime || b.EndTime <= desiredStartTime))
                .ToListAsync();

            return availableTables;
        }
    }
}
