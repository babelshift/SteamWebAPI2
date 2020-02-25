namespace Steam.Models.GameEconomy
{
    public class StoreConfigModel
    {
        public ulong DropdownId { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public ulong DefaultSelectionId { get; set; }
    }
}