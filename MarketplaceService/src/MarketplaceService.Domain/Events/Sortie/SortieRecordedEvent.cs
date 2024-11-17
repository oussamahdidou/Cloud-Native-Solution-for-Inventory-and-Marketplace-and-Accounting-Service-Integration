using EventsContracts.EventsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Events.Sortie
{
    public class SortieRecordedEvent : ISortieRecordedEvent
    {
        public List<ISortieItem> SortieItems { get; set; }= new List<ISortieItem>();
    }
}
