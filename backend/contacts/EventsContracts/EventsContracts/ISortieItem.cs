using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ISortieItem
    {
         string ProductId  { get; set; }
         int Quantity { get; set; }
    }
}
