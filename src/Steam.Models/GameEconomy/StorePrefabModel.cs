using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StorePrefabModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<StoreConfigModel> Config { get; set; }
    }
}