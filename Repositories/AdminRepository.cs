using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(MyCafeLabb1Context context) : base(context) { }

        public async Task<Admin?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Username == username);
        }
    }
}
