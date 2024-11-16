using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ICommandeItemEvent
    {
        int ItemId { set; get; }
        int Quantity { set; get; }
    }
}
