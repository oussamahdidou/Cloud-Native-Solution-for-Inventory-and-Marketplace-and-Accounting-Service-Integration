using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Entities
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public List<Commande> Commandes { get; set; }= new List<Commande>();
    }
}
