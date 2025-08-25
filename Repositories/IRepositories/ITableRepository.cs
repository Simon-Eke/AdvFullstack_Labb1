using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTablesAsync();
        Task<List<Table>> GetAvailableTablesAsync(int wantedSeats, DateTime desiredStartTime);
        Task<Table> GetTableByIdAsync(int tableId);
        Task<int> CreateTableAsync(Table newTable);
        Task<bool> UpdateTableAsync(Table table);
        Task<bool> PatchTableAsync(Table table);
        Task<bool> DeleteTableAsync(int tableId);
    }
}
