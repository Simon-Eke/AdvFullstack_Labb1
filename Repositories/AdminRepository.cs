using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;

namespace AdvFullstack_Labb1.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MyCafeLabb1Context _context;

        public AdminRepository(MyCafeLabb1Context context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Admin newAdmin)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int adminId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetByIdAsync(int adminId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PatchAsync(Admin admin)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
