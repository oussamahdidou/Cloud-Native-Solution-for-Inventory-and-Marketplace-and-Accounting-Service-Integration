using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsContracts.EventsContracts;


namespace MarketplaceService.Domain.Events.CategoryEvent
{
    public class CategoryAddedEvent: ICategoryAddedEvent
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}
