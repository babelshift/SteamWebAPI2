using System;

namespace Steam.Models.SteamCommunity
{
    public class PlayerSummaryModel
    {
        /// <summary>
        /// Unique Steam ID of the player. Resolve this using ResolveVanityUrl interface method.
        /// </summary>
        public ulong SteamId { get; set; }

        /// <summary>
        /// Determines the visibility of the user's profile (public, private, friends)
        /// </summary>
        public ProfileVisibility ProfileVisibility { get; set; }

        /// <summary>
        /// If set to 1, the user has configured his profile.
        /// </summary>
        public uint ProfileState { get; set; }

        /// <summary>
        /// User's current nick name (displayed in profile and friends list)
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// The date at which the user last logged off Steam
        /// It's a 64-bit integer in the JSON response, so we parse it to a DateTime
        /// </summary>
        public DateTime LastLoggedOffDate { get; set; }

        /// <summary>
        /// The selected privacy/visibility level of the player's comments section on their Steam Community profile
        /// </summary>
        public CommentPermission CommentPermission { get; set; }

        /// <summary>
        /// The URL for the player's Steam Community profile
        /// </summary>
        public string ProfileUrl { get; set; }

        /// <summary>
        /// The normal sized uploaded avatar image for the user's Steam profile
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The medium sized uploaded avatar image for the user's Steam profile
        /// </summary>
        public string AvatarMediumUrl { get; set; }

        /// <summary>
        /// THe full sized uploaded avatar image for the user's Steam profile
        /// </summary>
        public string AvatarFullUrl { get; set; }

        /// <summary>
        /// The current status of the user on the Steam network
        /// </summary>
        public UserStatus UserStatus { get; set; }

        /// <summary>
        /// The player's real name as entered on their Steam profile
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// The player's selected primary group to display on their Steam profile
        /// </summary>
        public string PrimaryGroupId { get; set; }

        /// <summary>
        /// The date at which the user created their Steam account
        /// It's a 64-bit integer in the JSON response, so we parse it to a DateTime
        /// </summary>
        public DateTime AccountCreatedDate { get; set; }

        /// <summary>
        /// The player's selected country
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The player's selected state
        /// </summary>
        public string StateCode { get; set; }

        /// <summary>
        /// The player's selected city. This seems to refer to a database city id, so I'm not sure how to make use of this field.
        /// </summary>
        public uint CityCode { get; set; }

        /// <summary>
        /// The name of the game that a player is currently playing
        /// </summary>
        public string PlayingGameName { get; set; }

        /// <summary>
        /// The id of the game that the player is currently playing. This doesn't seem to be an appid, so I'm not sure how to make use of this field.
        /// </summary>
        public string PlayingGameId { get; set; }
    }
}