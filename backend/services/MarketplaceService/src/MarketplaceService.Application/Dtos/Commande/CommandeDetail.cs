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
