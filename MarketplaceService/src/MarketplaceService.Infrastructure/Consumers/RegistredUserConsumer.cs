using EventsContracts.EventsContracts;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Events;
using MarketplaceService.Domain.Repositories;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Infrastructure.Consumers
{
    public class RegistredUserConsumer : IConsumer<INewUserRegistredEvent>
    {
        private readonly ICustomerRepository customerRepository;
        public RegistredUserConsumer(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task Consume(ConsumeContext<INewUserRegistredEvent> context)
        {
            await Console.Out.WriteLineAsync("message received from user registration");
            Customer customer = new Customer()
            {
                CustomerId = context.Message.CustomerId,
                UserName = context.Message.UserName,
            };
            await customerRepository.AddCustomerAsync(customer);
            
        }
    }
}
