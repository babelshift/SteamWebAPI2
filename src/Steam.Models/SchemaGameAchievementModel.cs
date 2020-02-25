namespace Steam.Models
{
    public class SchemaGameAchievementModel
    {
        public string Name { get; set; }

        public ulong DefaultValue { get; set; }

        public string DisplayName { get; set; }

        public uint Hidden { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Icongray { get; set; }
    }
}