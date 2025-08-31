using AdvFullstack_Labb1.Models.DTOs.MenuItem;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto> GetByIdAsync(int menuItemId);
        Task<int> CreateAsync(MenuItemCreateDto newMenuItem);
        Task<bool> UpdateAsync(MenuItemDto menuItem);
        Task<bool> PatchAsync(int id, MenuItemPatchDto patchMenuItem);
        Task<bool> DeleteAsync(int menuItemId);
    }
}
