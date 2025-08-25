using AdvFullstack_Labb1.Models.DTOs.Table;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface ITableService
    {
        Task<List<TableDto>> GetAllTablesAsync();
        Task<List<TableDto>> GetAvailableTablesAsync(int wantedSeats, DateTime desiredStartTime);
        Task<TableDto> GetTableByIdAsync(int tableId);
        Task<int> CreateTableAsync(TableCreateDto newTable);
        Task<bool> UpdateTableAsync(TableDto table);
        Task<bool> PatchTableAsync(int id, TablePatchDto patchTable);
        Task<bool> DeleteTableAsync(int tableId);
    }
}
