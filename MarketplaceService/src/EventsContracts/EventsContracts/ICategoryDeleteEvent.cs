using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ICategoryDeleteEvent
    {
        public string CategoryId { get; }
    }
}
