using MarketplaceService.Domain.Entities;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByUsername(string username);
    }
}
