using AdvFullstack_Labb1.Models.DTOs.Customer;

namespace AdvFullstack_Labb1.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int customerId);
        Task<int> CreateAsync(CustomerCreateDto newCustomer);
        Task<bool> UpdateAsync(CustomerDto customer);
        Task<bool> PatchAsync(int id, CustomerPatchDto patchCustomer);
        Task<bool> DeleteAsync(int customerId);
    }
}
