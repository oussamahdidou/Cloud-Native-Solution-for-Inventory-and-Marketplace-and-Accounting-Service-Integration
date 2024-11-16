using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDbContext apiDbContext;

        public CustomerRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await apiDbContext.customers.AddAsync(customer);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await apiDbContext.customers.FindAsync(id);
            if (customer != null)
            {
                apiDbContext.customers.Remove(customer);
                await apiDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await apiDbContext.customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await apiDbContext.customers.FindAsync(id);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await apiDbContext.customers.FindAsync(customer.CustomerId);
            if (existingCustomer != null)
            {
                apiDbContext.Entry(existingCustomer).CurrentValues.SetValues(customer);
                await apiDbContext.SaveChangesAsync();
            }
        }
    }
}
