using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICustomerRepository
    {
        // Get all customers
        Task<List<Customer>> GetAllCustomersAsync();

        // Get a customer by ID
        Task<Customer> GetCustomerByIdAsync(int id);

        // Add a new customer
        Task AddCustomerAsync(Customer customer);

        // Update an existing customer
        Task UpdateCustomerAsync(Customer customer);

        // Delete a customer by ID
        Task DeleteCustomerAsync(int id);
    }
}
