using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Domain.Entities
{
    public class CommandeProduct
    {
       
        public int ProductId { get; set; }
        public int CommandeId { get; set; }
        public Product? Product { get; set; }
        public Commande? Commande { get; set; }
    }
}
