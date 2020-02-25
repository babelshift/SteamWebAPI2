namespace Steam.Models
{
    public class SchemaForGameResultModel
    {
        public string GameName { get; set; }

        public string GameVersion { get; set; }

        public AvailableGameStatsModel AvailableGameStats { get; set; }
    }
}