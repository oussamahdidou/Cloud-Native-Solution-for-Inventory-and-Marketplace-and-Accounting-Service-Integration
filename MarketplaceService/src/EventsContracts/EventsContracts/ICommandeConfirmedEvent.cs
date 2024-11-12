using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ICommandeConfirmedEvent
    {
        List<ICommandeItemEvent> Items { set; get; }
         
        DateTime Date { set; get; }

    }
}
