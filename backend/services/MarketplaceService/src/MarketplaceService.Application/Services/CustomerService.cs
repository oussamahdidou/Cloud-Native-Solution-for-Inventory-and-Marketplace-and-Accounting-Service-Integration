using MarketplaceService.Application.Dtos.Products;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Domain.Caching;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IRedisCachingService redisCachingService;

        public CustomerService(ICustomerRepository customerRepository, IRedisCachingService redisCachingService)
        {
            this.customerRepository = customerRepository;
            this.redisCachingService = redisCachingService;
        }
        public async Task<Customer> GetCustomerByUsername(string username)
        {
            Customer? customer = await redisCachingService.GetElementByKeyAsync<Customer>(username);
            if (customer != null) { return customer; }
            Customer? dbcustomer = await customerRepository.GetCustomerByUsernameAsync(username);
            if (dbcustomer == null) throw new KeyNotFoundException();
            return await redisCachingService.AddItemToCacheAsync<Customer>(dbcustomer, username);
        }
    }
}
