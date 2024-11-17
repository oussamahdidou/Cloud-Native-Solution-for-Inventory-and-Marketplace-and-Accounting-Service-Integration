using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Dtos.Commande
{
    public class CommandeDetail
    {
        public int CommandeId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime Date { get; set; }
    }
}
