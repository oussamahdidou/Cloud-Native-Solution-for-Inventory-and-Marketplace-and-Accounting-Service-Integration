using EventsContracts.EventsContracts;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MassTransit;

namespace MarketplaceService.Infrastructure.Consumers
{
    public class ProductAddedConsumer : IConsumer<IProductAddedEvent>
    {
        private readonly IProductRepository productRepository;
        public ProductAddedConsumer(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Consume(ConsumeContext<IProductAddedEvent> context)
        {
            await Console.Out.WriteLineAsync("message received from  database of product spring boot");
            Product product = new Product()
            {
                ProductId = context.Message.Id,
                MarqueName = context.Message.MarqueName,
                MarqueIcon = context.Message.MarqueIcon,
                Name = context.Message.Name,
                Description = context.Message.Description,
                Price = context.Message.Price,
                Quantity = context.Message.Quantity,
                Thumbnail = context.Message.Thumbnail,
                CategoryId = context.Message.CategoryId,
            };
            await Console.Out.WriteLineAsync("message wsl hna o hbs");
            await productRepository.AddProductAsync(product);
            await Console.Out.WriteLineAsync("dgfiuasfguasif");


        }

    }
}
