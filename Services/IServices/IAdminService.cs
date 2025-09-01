using AdvFullstack_Labb1.Models.DTOs.Admin;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetAllAsync();
        Task<AdminDto> GetByIdAsync(int adminId);
        Task<int> CreateAsync(AdminCreateDto newAdmin);
        Task<bool> UpdateAsync(AdminPutDto admin);
        Task<bool> PatchAsync(int id, AdminPatchDto patchAdmin);
        Task<bool> DeleteAsync(int adminId);
    }
}
