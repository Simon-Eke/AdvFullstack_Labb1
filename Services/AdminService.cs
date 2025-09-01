using AdvFullstack_Labb1.Models.DTOs.Admin;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.Shared;
using AdvFullstack_Labb1.Services.IServices;

namespace AdvFullstack_Labb1.Services
{
    public class AdminService : IAdminService 
    {
        private readonly IAdminRepository _repo;
        private readonly PasswordHasher _hasher;
        public AdminService(IAdminRepository repo, PasswordHasher hasher)
        {
            _repo = repo;
            _hasher = hasher;
        }

        public async Task<List<AdminDto>> GetAllAsync()
        {
            var admins = await _repo.GetAllAsync();

            var adminDtoList = admins.Select(a => new AdminDto
            {
                Id = a.Id,
                Username = a.Username
            }).ToList();

            return adminDtoList;
        }

        public async Task<AdminDto> GetByIdAsync(int adminId)
        {
            var admin = await _repo.GetByIdAsync(adminId);

            if (admin == null)
                return null;

            var adminDto = new AdminDto
            {
                Id = admin.Id,
                Username = admin.Username
            };

            return adminDto;
        }
        public async Task<int> CreateAsync(AdminCreateDto newAdmin)
        {
            var admin = new Admin
            {
                Username = newAdmin.Username,
                PasswordHash = _hasher.HashPassword(newAdmin.Password)
            };

            var newAdminId = await _repo.CreateAsync(admin);

            return newAdminId;
        }
        public async Task<bool> UpdateAsync(AdminPutDto admin)
        {
            var existingAdmin = await _repo.GetByIdAsync(admin.Id);
            if (existingAdmin == null)
                return false;

            existingAdmin.Username = admin.Username;
            if (!string.IsNullOrEmpty(admin.Password))
                existingAdmin.PasswordHash = _hasher.HashPassword(admin.Password);


            await _repo.UpdateAsync(existingAdmin);

            return true;
        }
        public async Task<bool> PatchAsync(int id, AdminPatchDto patchAdmin)
        {
            var existingAdmin = await _repo.GetByIdAsync(id);
            if (existingAdmin == null)
                return false;

            if (!string.IsNullOrEmpty(patchAdmin.Username))
                existingAdmin.Username = patchAdmin.Username;

            if (!string.IsNullOrEmpty(patchAdmin.Password))
                existingAdmin.PasswordHash = _hasher.HashPassword(patchAdmin.Password);

            var success = await _repo.UpdateAsync(existingAdmin);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteAsync(int adminId)
        {
            var existingAdmin = await _repo.GetByIdAsync(adminId);
            if (existingAdmin == null)
                return false;

            var success = await _repo.DeleteAsync(adminId);
            if (success != true)
                return false;

            return true;
        }
    }
}
