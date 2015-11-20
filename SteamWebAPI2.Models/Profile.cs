using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{

    public class Profile
    {
        public long SteamID { get; set; }
        public string Nickname { get; set; }
        public string State { get; set; }
        public string StateMessage { get; set; }
        public int VisibilityState { get; set; } // what is this?
        public Uri Avatar { get; set; }
        public Uri AvatarMedium { get; set; }
        public Uri AvatarFull { get; set; }
        public bool IsVacBanned { get; set; }
        public string TradeBanState { get; set; }
        public bool IsLimitedAccount { get; set; }
        public string CustomURL { get; set; }
        public string MemberSince { get; set; }
        public double SteamRating { get; set; }
        public double HoursPlayedLastTwoWeeks { get; set; }
        public string Headline { get; set; }
        public string Location { get; set; }
        public string RealName { get; set; }
        public string Summary { get; set; }
        public IList<MostPlayedGame> MostPlayedGames { get; set; }
        public IList<WebLink> WebLinks { get; set; }

        public class MostPlayedGame
        {
            public string Name { get; set; }
            public Uri Link { get; set; }
            public Uri Icon { get; set; }
            public Uri Logo { get; set; }
            public Uri LogoSmall { get; set; }
            public double HoursPlayed { get; set; }
            public double HoursOnRecord { get; set; }
            public string StatsName { get; set; }
        }

        public class WebLink
        {
            public string Title { get; set; }
            public Uri Link { get; set; }
        }
    }
}
