using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly MyCafeLabb1Context _context;
        public TableRepository(MyCafeLabb1Context context)
        {
            _context = context;
        }
        public async Task<List<Table>> GetAllTablesAsync()
        {
            var tables = await _context.Tables.ToListAsync();

            return tables;
        }

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
        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t => t.TableId == tableId);

            return table;
        }
        public async Task<int> CreateTableAsync(Table newTable)
        {
            _context.Tables.Add(newTable);
            await _context.SaveChangesAsync();

            return newTable.TableId;
        }
        public async Task<bool> UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected != 0)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> PatchTableAsync(Table table)
        {
            _context.Tables.Update(table);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected != 0)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> DeleteTableAsync(int tableId)
        {
            int rowsAffected = await _context.Tables
                .Where(t => t.TableId == tableId)
                .ExecuteDeleteAsync();

            if (rowsAffected != 0)
            {
                return true;
            }

            return false;
        }
    }
}
