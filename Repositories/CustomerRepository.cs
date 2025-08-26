using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;

namespace AdvFullstack_Labb1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyCafeLabb1Context _context;

        public CustomerRepository(MyCafeLabb1Context context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PatchAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
