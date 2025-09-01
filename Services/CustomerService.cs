using AdvFullstack_Labb1.Models.DTOs.Customer;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;

namespace AdvFullstack_Labb1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();

            var customerDtoList = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber
            }).ToList();

            return customerDtoList;
        }

        public async Task<CustomerDto> GetByIdAsync(int customerId)
        {
            var customer = await _repo.GetByIdAsync(customerId);

            if (customer == null)
                return null;

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber
            };

            return customerDto;
        }
        public async Task<int> CreateAsync(CustomerCreateDto newCustomer)
        {
            var customer = new Customer
            {
                Name = newCustomer.Name,
                PhoneNumber = newCustomer.PhoneNumber
            };

            var newCustomerId = await _repo.CreateAsync(customer);

            return newCustomerId;
        }
        public async Task<bool> UpdateAsync(CustomerDto customer)
        {
            var existingCustomer = await _repo.GetByIdAsync(customer.Id);
            if (existingCustomer == null)
                return false;

            existingCustomer.Name = customer.Name;
            existingCustomer.PhoneNumber = customer.PhoneNumber;


            await _repo.UpdateAsync(existingCustomer);

            return true;
        }
        public async Task<bool> PatchAsync(int id, CustomerPatchDto patchCustomer)
        {
            var existingCustomer = await _repo.GetByIdAsync(id);
            if (existingCustomer == null)
                return false;

            if (!string.IsNullOrEmpty(patchCustomer.Name))
                existingCustomer.Name = patchCustomer.Name;

            if (!string.IsNullOrEmpty(patchCustomer.PhoneNumber))
                existingCustomer.PhoneNumber = patchCustomer.PhoneNumber;

            var success = await _repo.UpdateAsync(existingCustomer);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteAsync(int customerId)
        {
            var existingCustomer = await _repo.GetByIdAsync(customerId);
            if (existingCustomer == null)
                return false;

            var success = await _repo.DeleteAsync(customerId);
            if (success != true)
                return false;

            return true;
        }
    }
}
