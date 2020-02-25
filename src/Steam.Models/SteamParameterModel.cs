namespace Steam.Models
{
    public class SteamParameterModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public bool IsOptional { get; set; }

        public string Description { get; set; }
    }
}