using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsContracts.EventsContracts
{
    public interface INewUserRegistredEvent
    {
        string CustomerId { get; set; }
        string UserName { get; set; }
    }
}
