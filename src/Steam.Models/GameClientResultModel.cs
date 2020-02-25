namespace Steam.Models
{
    public class GameClientResultModel
    {
        public bool Success { get; set; }

        public uint DeployVersion { get; set; }

        public uint ActiveVersion { get; set; }
    }
}