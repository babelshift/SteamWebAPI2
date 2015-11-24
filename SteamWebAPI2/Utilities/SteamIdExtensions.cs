namespace SteamWebAPI2.Utilities
{
    public static class SteamIdExtensions
    {
        private const long offset = 76561197960265728;

        /// <summary>
        /// 32 bit Steam ID is used in DOTA2 related APIs, sometimes referred to as "account id" in the documentation.
        /// </summary>
        /// <param name="steamId64"></param>
        /// <returns></returns>
        public static int ToSteamId32(this long steamId64)
        {
            return (int)(steamId64 - offset);
        }

        /// <summary>
        /// 64 bit Steam ID is used in Steam Community related APIs.
        /// </summary>
        /// <param name="steamId32"></param>
        /// <returns></returns>
        public static long ToSteamId64(this int steamId32)
        {
            return (long)(steamId32 + offset);
        }
    }
}