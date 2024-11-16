using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface IProductDeleteEvent
    {
        public string Id { get; set; }
    }
}
