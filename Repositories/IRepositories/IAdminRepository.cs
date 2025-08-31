using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin?> GetByUsernameAsync(string username);
    }
}
