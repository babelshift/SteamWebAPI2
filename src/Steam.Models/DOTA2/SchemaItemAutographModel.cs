namespace Steam.Models.DOTA2
{
    public class SchemaItemAutographModel
    {
        public string DefIndex { get; set; }

        public string Name { get; set; }

        public string Autograph { get; set; }

        public ulong? WorkshopLink { get; set; }

        public uint Language { get; set; }

        public string IconPath { get; set; }

        public string Modifier { get; set; }
    }
}