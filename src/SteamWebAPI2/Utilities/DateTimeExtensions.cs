using System;

namespace SteamWebAPI2.Utilities
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a Unix time to DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this ulong unixTimeStamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(unixTimeStamp);
        }

        /// <summary>
        /// Converts a DateTime to Unix time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static ulong ToUnixTimeStamp(this DateTime dateTime)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            TimeSpan timeSpanSinceOrigin = dateTime.Subtract(origin);

            return Convert.ToUInt64(timeSpanSinceOrigin.TotalSeconds);
        }
    }
}