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
    public class UpdateCategoryConsumer : IConsumer<IUpdateCategoryEvent>
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategoryConsumer(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task Consume(ConsumeContext<IUpdateCategoryEvent> context)
        {
            await Console.Out.WriteLineAsync("filter the message to update category ");
            Category category = new Category()
            {
                CategoryId = context.Message.CategoryId,
                Name = context.Message.Name,
                Thumbnail = context.Message.Thumbnail,
            };
            await categoryRepository.UpdateCategoryAsync(category);
            await Console.Out.WriteLineAsync("category Updated");

        }
    }
}
