using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<MenuItem> GetByIdAsync(int menuItemId);
        Task<int> CreateAsync(MenuItem newTable);
        Task<bool> UpdateAsync(MenuItem menuItem);
        Task<bool> PatchAsync(MenuItem menuItem);
        Task<bool> DeleteAsync(int menuItemId);
    }
}
