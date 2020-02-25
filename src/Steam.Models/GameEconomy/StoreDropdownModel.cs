namespace Steam.Models.GameEconomy
{
    public class StoreDropdownModel
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string LabelText { get; set; }

        public string UrlHistoryParamName { get; set; }
    }
}