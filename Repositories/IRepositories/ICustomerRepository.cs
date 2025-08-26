using AdvFullstack_Labb1.Models.Entities;

namespace AdvFullstack_Labb1.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int customerId);
        Task<int> CreateAsync(Customer newCustomer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> PatchAsync(Customer customer);
        Task<bool> DeleteAsync(int customerId);
    }
}
