using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyCafeLabb1Context context) : base(context) { }

        public async Task<Customer?> GetByNameAndPhoneAsync(string name, string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(c =>
                    c.Name == name &&
                    c.PhoneNumber == phoneNumber);
        }
    }
}
