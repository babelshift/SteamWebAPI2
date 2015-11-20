using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class PlayerSummaryResponse
    {
        public IList<PlayerSummary> Players { get; set; }
    }
}
