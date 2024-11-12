using EventsContracts.EventsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Events
{
    public class CommandeConfirmedEvent : ICommandeConfirmedEvent
    {
        public List<ICommandeItemEvent> Items { get; set; }
        public DateTime Date { get ; set ; }
    }
}
