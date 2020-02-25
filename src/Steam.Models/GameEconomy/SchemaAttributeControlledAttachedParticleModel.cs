namespace Steam.Models.GameEconomy
{
    public class SchemaAttributeControlledAttachedParticleModel
    {
        public string System { get; set; }

        public uint Id { get; set; }

        public bool AttachToRootbone { get; set; }

        public string Name { get; set; }

        public string Attachment { get; set; }
    }
}