using AdvFullstack_Labb1.Models.DTOs.MenuItem;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;

namespace AdvFullstack_Labb1.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repo;

        public MenuItemService(IMenuItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MenuItemDto>> GetAllAsync()
        {
            var menuItems = await _repo.GetAllAsync();

            var menuItemDtoList = menuItems.Select(mi => new MenuItemDto
            {
                Id = mi.Id,
                Name = mi.Name,
                Price = mi.Price,
                IsPopular = mi.IsPopular,
                ImageUrl = mi.ImageUrl
            }).ToList();

            return menuItemDtoList;
        }

        public async Task<MenuItemDto> GetByIdAsync(int menuItemId)
        {
            var menuItem = await _repo.GetByIdAsync(menuItemId);

            if (menuItem == null)
                return null;

            var menuItemDto = new MenuItemDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                IsPopular = menuItem.IsPopular,
                ImageUrl = menuItem.ImageUrl
            };

            return menuItemDto;
        }
        public async Task<int> CreateAsync(MenuItemCreateDto newMenuItem)
        {
            var menuItem = new MenuItem
            {
                Name = newMenuItem.Name,
                Price = newMenuItem.Price,
                IsPopular = newMenuItem.IsPopular,
                ImageUrl = newMenuItem.ImageUrl
            };

            var newMenuItemId = await _repo.CreateAsync(menuItem);

            return newMenuItemId;
        }
        public async Task<bool> UpdateAsync(MenuItemDto menuItem)
        {
            var existingMenuItem = await _repo.GetByIdAsync(menuItem.Id);
            if (existingMenuItem == null)
                return false;

            existingMenuItem.Name = menuItem.Name;
            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.IsPopular = menuItem.IsPopular;
            existingMenuItem.ImageUrl = menuItem.ImageUrl;


            await _repo.UpdateAsync(existingMenuItem);

            return true;
        }
        public async Task<bool> PatchAsync(int id, MenuItemPatchDto patchMenuItem)
        {
            var existingMenuItem = await _repo.GetByIdAsync(id);
            if (existingMenuItem == null)
                return false;

            if (!string.IsNullOrEmpty(patchMenuItem.Name))
                existingMenuItem.Name = patchMenuItem.Name;

            if (patchMenuItem.Price.HasValue)
                existingMenuItem.Price = patchMenuItem.Price.Value;

            if (patchMenuItem.IsPopular.HasValue)
                existingMenuItem.IsPopular = patchMenuItem.IsPopular.Value;

            if (!string.IsNullOrEmpty(patchMenuItem.ImageUrl))
                existingMenuItem.ImageUrl = patchMenuItem.ImageUrl;

            var success = await _repo.UpdateAsync(existingMenuItem);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteAsync(int menuItemId)
        {
            var existingMenuItem = await _repo.GetByIdAsync(menuItemId);
            if (existingMenuItem == null)
                return false;

            var success = await _repo.DeleteAsync(menuItemId);
            if (success != true)
                return false;

            return true;
        }
    }
}
