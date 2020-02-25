namespace Steam.Models.DOTA2
{
    public class GameItemModel
    {
        public uint Id { get; set; }
        public uint Cost { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public bool IsRecipe { get; set; }
        public bool IsAvailableAtSecretShop { get; set; }
        public bool IsAvailableAtSideShop { get; set; }
    }
}