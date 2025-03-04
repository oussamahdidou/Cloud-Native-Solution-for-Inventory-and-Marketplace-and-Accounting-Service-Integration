using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Domain.Repositories
{
    public interface ICustomerRepository
    {
        // Get all customers
        Task<List<Customer>> GetAllCustomersAsync();

        // Get a customer by ID
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<Customer> GetCustomerByUsernameAsync(string username);
        // Add a new customer
        Task AddCustomerAsync(Customer customer);

        // Update an existing customer
        Task UpdateCustomerAsync(Customer customer);

        // Delete a customer by ID
        Task DeleteCustomerAsync(int id);
    }
}
