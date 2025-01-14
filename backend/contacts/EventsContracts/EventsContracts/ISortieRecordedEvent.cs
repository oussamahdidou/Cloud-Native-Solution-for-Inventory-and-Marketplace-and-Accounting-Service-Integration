namespace EventsContracts.EventsContracts
{
    public interface ISortieRecordedEvent
    {
        public DateTime Date { get; set; }
        List<ISortieItem> SortieItems { get; set; }
    }
}
