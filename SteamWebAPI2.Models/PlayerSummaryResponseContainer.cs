using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    /// <summary>
    /// Represents the container of the response from ISteamUser/GetPlayerSummaries interface/method.
    /// </summary>
    public class PlayerSummaryResponseContainer
    {
        /// <summary>
        /// The JSON response has a top level "response" object
        /// </summary>
        public PlayerSummaryResponse Response { get; set; }
    }
}
