using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int adminId);
        Task<int> CreateAsync(Admin newAdmin);
        Task<bool> UpdateAsync(Admin admin);
        Task<bool> PatchAsync(Admin admin);
        Task<bool> DeleteAsync(int adminId);
    }
}
