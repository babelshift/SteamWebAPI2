using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    /// <summary>
    /// Represents the list of player summaries from ISteamUser/GetPlayerSummaries interface/method.
    /// </summary>
    public class PlayerSummaryResponse
    {
        /// <summary>
        /// Contains the list of player summaries in the JSON response.
        /// </summary>
        public IList<PlayerSummary> Players { get; set; }
    }
}
