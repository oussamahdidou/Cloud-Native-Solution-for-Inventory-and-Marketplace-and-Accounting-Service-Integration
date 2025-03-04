namespace EventsContracts.EventsContracts
{
    public interface IProductAddedEvent
    {
        public string Id { get; set; }
        public string MarqueName { get; set; }
        public string MarqueIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public string CategoryId { get; set; }
    }
}
