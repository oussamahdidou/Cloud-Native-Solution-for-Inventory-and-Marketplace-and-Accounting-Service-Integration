using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface ICategoryAddedEvent
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}
