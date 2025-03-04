namespace EventsContracts.EventsContracts
{
    public class IUpdateCategoryEvent
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}
