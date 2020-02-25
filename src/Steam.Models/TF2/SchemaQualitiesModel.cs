using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaQualitiesModel
    {
        /// <summary>
        /// Normal item rarity: https://wiki.teamfortress.com/wiki/Normal
        /// </summary>
        public uint Normal { get; set; }

        /// <summary>
        /// Genuine item rarity: https://wiki.teamfortress.com/wiki/Genuine
        /// </summary>
        public uint Rarity1 { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public uint Rarity2 { get; set; }

        /// <summary>
        /// Vintage item rarity: https://wiki.teamfortress.com/wiki/Vintage
        /// </summary>
        public uint Vintage { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public uint Rarity3 { get; set; }

        /// <summary>
        /// Unusual item rarity: https://wiki.teamfortress.com/wiki/Unusual
        /// </summary>
        public uint Rarity4 { get; set; }

        /// <summary>
        /// Unique item rarity: https://wiki.teamfortress.com/wiki/Unique
        /// </summary>
        public uint Unique { get; set; }

        /// <summary>
        /// Community item: https://wiki.teamfortress.com/wiki/Community_(quality)
        /// </summary>
        public uint Community { get; set; }

        /// <summary>
        /// Developer owned item: https://wiki.teamfortress.com/wiki/Valve_(quality)
        /// </summary>
        public uint Developer { get; set; }

        /// <summary>
        /// Self made item: https://wiki.teamfortress.com/wiki/Self-Made
        /// </summary>
        public uint SelfMade { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public uint Customized { get; set; }

        /// <summary>
        /// Strange item: https://wiki.teamfortress.com/wiki/Strange
        /// </summary>
        public uint Strange { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public uint Completed { get; set; }

        /// <summary>
        /// Haunted item: https://wiki.teamfortress.com/wiki/Haunted
        /// </summary>
        public uint Haunted { get; set; }

        /// <summary>
        /// Collector's item: https://wiki.teamfortress.com/wiki/Collector%27s
        /// </summary>
        public uint Collectors { get; set; }
        
        public uint PaintKitWeapon { get; set; }
    }
}
