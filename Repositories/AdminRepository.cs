using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;

namespace AdvFullstack_Labb1.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(MyCafeLabb1Context context) : base(context) { }
    }
}
