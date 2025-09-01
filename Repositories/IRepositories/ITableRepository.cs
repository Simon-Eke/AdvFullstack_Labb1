using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface ITableRepository : IRepository<Table>
    {
        Task<List<Table>> GetAvailableTablesAsync(int wantedSeats, DateTime desiredStartTime);
        Task<bool> IsAvailableAsync(int id, DateTime startTime);
    }
}
