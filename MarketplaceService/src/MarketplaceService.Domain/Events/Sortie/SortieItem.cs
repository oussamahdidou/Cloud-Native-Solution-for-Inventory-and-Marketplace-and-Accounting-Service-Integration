using EventsContracts.EventsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Events.Sortie
{
    public class SortieItem : ISortieItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
