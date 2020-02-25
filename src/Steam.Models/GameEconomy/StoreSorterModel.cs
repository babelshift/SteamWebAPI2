namespace Steam.Models.GameEconomy
{
    public class StoreSorterModel
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public string DataType { get; set; }

        public string SortField { get; set; }

        public bool SortReversed { get; set; }

        public string LocalizedText { get; set; }
    }
}