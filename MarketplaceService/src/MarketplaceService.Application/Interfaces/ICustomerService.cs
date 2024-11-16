using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByUsername(string username);
    }
}
