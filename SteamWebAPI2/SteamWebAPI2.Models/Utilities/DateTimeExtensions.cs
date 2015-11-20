using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.Utilities
{
    internal static class DateTimeExtensions
    {
        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(unixTimeStamp);
        }

        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            TimeSpan timeSpanSinceOrigin = dateTime.Subtract(origin);

            return Convert.ToInt64(timeSpanSinceOrigin.TotalSeconds);
        }
    }
}
