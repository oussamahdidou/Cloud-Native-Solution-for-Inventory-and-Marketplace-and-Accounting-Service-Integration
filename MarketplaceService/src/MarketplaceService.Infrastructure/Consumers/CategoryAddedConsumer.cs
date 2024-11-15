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
    public class CategoryAddedConsumer: IConsumer<ICategoryAddedEvent>
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryAddedConsumer(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task Consume(ConsumeContext<ICategoryAddedEvent> context)
        {
            await Console.Out.WriteLineAsync("message received from category DB ");
            Category category = new Category()
            {
                CategoryId = context.Message.CategoryId,
                Name = context.Message.Name,
                Thumbnail = context.Message.Thumbnail,
            };
            await categoryRepository.AddCategoryAsync(category);

        }
    }
}
