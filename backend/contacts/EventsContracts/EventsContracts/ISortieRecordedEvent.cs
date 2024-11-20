using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ISortieRecordedEvent
    {
        List<ISortieItem> SortieItems { get; set; }
    }
}
