using EventsContracts.EventsContracts;
using MarketplaceService.Domain.Entities;
using MarketplaceService.Domain.Repositories;
using MassTransit;

namespace MarketplaceService.Infrastructure.Consumers
{
    public class ProductUpdateConsumer : IConsumer<IupdateProductEvent>
    {
        private readonly IProductRepository productRepository;
        public ProductUpdateConsumer(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Consume(ConsumeContext<IupdateProductEvent> context)
        {
            await Console.Out.WriteLineAsync("Product ready to update spring boot");
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
            await Console.Out.WriteLineAsync("product t affecta");
            await productRepository.UpdateProductAsync(product);
            await Console.Out.WriteLineAsync("product t updata");


        }
    }
}
