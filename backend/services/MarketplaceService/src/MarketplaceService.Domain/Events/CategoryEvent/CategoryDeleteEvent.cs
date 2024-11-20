using EventsContracts.EventsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Events.CategoryEvent
{
    public class CategoryDeleteEvent: ICategoryDeleteEvent
    {
        public string CategoryId { get; set; }
    }
}
