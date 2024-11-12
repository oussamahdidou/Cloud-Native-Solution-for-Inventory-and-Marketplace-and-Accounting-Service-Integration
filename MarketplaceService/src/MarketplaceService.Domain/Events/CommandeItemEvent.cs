using EventsContracts.EventsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Events
{
    public class CommandeItemEvent : ICommandeItemEvent
    {
        public int ItemId { get ; set ; }
        public int Quantity { get ; set ; }
    }
}
