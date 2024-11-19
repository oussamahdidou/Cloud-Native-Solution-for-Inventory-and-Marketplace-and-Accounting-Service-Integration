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
    public class SortieRecordConsumer : IConsumer<ISortieRecordedEvent>
    {
        private readonly IProductRepository productRepository;

        public SortieRecordConsumer(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Consume(ConsumeContext<ISortieRecordedEvent> context)
        {
            ISortieRecordedEvent sortieRecordedEvent = context.Message;
            foreach (var item in sortieRecordedEvent.SortieItems)
            {
               Product product= await productRepository.GetProductByIdAsync(item.ProductId);
               product.Quantity=item.Quantity;
               await productRepository.UpdateProductAsync(product);
            }
        }
    }
}
