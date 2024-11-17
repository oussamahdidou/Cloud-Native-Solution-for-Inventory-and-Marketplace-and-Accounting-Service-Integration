using EventsContracts.EventsContracts;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Infrastructure.Consumers
{
    public class DeleteCategoryConsumer : IConsumer<ICategoryDeleteEvent>
    {
        private readonly ICategoryRepository categoryRepository;
        public DeleteCategoryConsumer(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task Consume(ConsumeContext<ICategoryDeleteEvent> context)
        {
            await Console.Out.WriteLineAsync("get Id from the message to delete category");
            string id = context.Message.CategoryId;
            await categoryRepository.DeleteCategoryAsync(id);
            await Console.Out.WriteLineAsync("the category deletes");

        }
    }
}
