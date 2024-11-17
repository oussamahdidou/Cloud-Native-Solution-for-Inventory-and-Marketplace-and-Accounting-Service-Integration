using MarketplaceService.Application.Interfaces;
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

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Customer> GetCustomerByUsername(string username)
        {
            Customer customer = await customerRepository.GetCustomerByUsernameAsync(username);
            return customer;
        }
    }
}
