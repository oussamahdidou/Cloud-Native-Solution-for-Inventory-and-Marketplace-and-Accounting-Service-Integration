using EventsContracts.EventsContracts;
using MarketplaceService.Domain.Repositories;
using MassTransit;

namespace MarketplaceService.Infrastructure.Consumers
{
    public class ProductDeleteConsumer : IConsumer<IProductDeleteEvent>
    {
        private readonly IProductRepository productRepository;
        public ProductDeleteConsumer(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Consume(ConsumeContext<IProductDeleteEvent> context)
        {
            await Console.Out.WriteLineAsync("Product ready to delete");
            string Id = context.Message.Id;
            await productRepository.DeleteProductAsync(Id);
            await Console.Out.WriteLineAsync("product Deleted");


        }
    }

}
