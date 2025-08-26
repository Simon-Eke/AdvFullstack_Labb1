using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;

namespace AdvFullstack_Labb1.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly MyCafeLabb1Context _context;

        public MenuItemRepository(MyCafeLabb1Context context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(MenuItem newTable)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MenuItem> GetByIdAsync(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PatchAsync(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
