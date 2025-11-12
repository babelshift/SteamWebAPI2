using SteamWebAPI2.Exceptions;
using SteamWebAPI2.Interfaces;
using System;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    #region Enum Types

    public enum SteamIdResolvedFrom
    {
        IndividualComponents = 0,
        SteamCommunityUri,
        SteamCommunityProfileName,
        SteamId64,
        AccountIdApproximation,
        LegacySteamId,
        ModernSteamId
    }

    public enum SteamUniverse
    {
        Invalid = 0,
        Public,
        Beta,
        Internal,
        Dev
    }

    public enum SteamAccountType
    {
        Invalid = 0,
        Individual = 1,
        Multiseat = 2,
        GameServer = 3,
        AnonGameServer = 4,
        Pending = 5,
        ContentServer = 6,
        Clan = 7,
        Chat = 8,
        Chat_Clan = 8,
        Chat_Lobby = 8,
        P2P_SuperSeeder = 9,
        AnonUser = 10
    }

    public enum SteamInstance
    {
        All = 0,
        Desktop = 1,
        Console = 2,
        Web = 4
    }

    #endregion Enum Types

    /// <summary>
    /// A SteamID (64-bit identifier) is a unique identifier used to identify a Steam account on various parts of the Steam network.
    /// It is also used to refer to a user's Steam Community profile page. See: https://developer.valvesoftware.com/wiki/SteamID.
    /// This class is immutable. If you need a new one, construct a new one.
    /// </summary>
    public class SteamId
    {
        #region Members

        private ISteamUser steamUser;

        // Special flags for chat accounts in the high 8 bits of the Steam ID instance. Adopted from https://github.com/xPaw/SteamID.php.
        //private uint instanceFlagClan = 524288;         // (SteamAccountInstanceMask + 1) >> 1
        //private uint instanceFlagLobby = 262144;        // (SteamAccountInstanceMask + 1) >> 2
        //private uint instanceFlagMMSLobby = 131072;     // (SteamAccountInstanceMask + 1) >> 3

        private SteamAccountType accountType;

        #endregion Members

        #region Properties

        /// <summary>
        /// Identifies which Steam system this Steam Id belongs to. Most Steam Ids are Public (1).
        /// </summary>
        public SteamUniverse Universe { get; private set; }

        /// <summary>
        /// Identifies the account type of the Steam Id. Most Steam Ids are Individual (1).
        /// </summary>
        public SteamAccountType AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                if (accountType == SteamAccountType.Individual || accountType == SteamAccountType.GameServer)
                {
                    Instance = SteamInstance.Desktop;
                }
                else if (accountType == SteamAccountType.Clan)
                {
                    Instance = SteamInstance.All;
                }
            }
        }

        /// <summary>
        /// Seems to indicate the system group from which a user is connecting such as "Desktop", "Console", or "Web". Most common is "Desktop".
        /// </summary>
        public SteamInstance Instance { get; private set; }

        /// <summary>
        /// A user's unique account id (sometimes incorrectly referred to as "SteamId32" or "32-bit Steam Id". This is the lowest 32-bits of the 64-bit Steam Id. Used as
        /// an identifier in Dota 2.
        /// </summary>
        public uint AccountId { get; private set; }

        /// <summary>
        /// Indicates how the Steam Id was resolved (from url, components, 64-bit id, etc...)
        /// </summary>
        public SteamIdResolvedFrom ResolvedFrom { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a Steam Id from the four components.
        /// </summary>
        /// <param name="universe">Which Steam system this Steam Id belongs to (such as Public)</param>
        /// <param name="accountType">The type of account for this Steam Id (such as Individual)</param>
        /// <param name="accountId">The 32-bit account identifier for the Steam account</param>
        /// <param name="instance">Not really sure. It seems to mostly be "1".</param>
        public SteamId(SteamUniverse universe, SteamAccountType accountType, uint accountId, SteamInstance instance)
        {
            Universe = universe;
            AccountType = accountType;
            Instance = instance;
            AccountId = accountId;

            ResolvedFrom = SteamIdResolvedFrom.IndividualComponents;
        }

        /// <summary>
        /// Constructs a Steam Id from three of the four components. Instance is defaulted to a value based on the Account Type.
        /// </summary>
        /// <param name="universe">Which Steam system this Steam Id belongs to (such as Public)</param>
        /// <param name="accountType">The type of account for this Steam Id (such as Individual)</param>
        /// <param name="accountId">The 32-bit account identifier for the Steam account</param>
        public SteamId(SteamUniverse universe, SteamAccountType accountType, uint accountId)
        {
            Universe = universe;
            AccountType = accountType;
            AccountId = accountId;

            ResolvedFrom = SteamIdResolvedFrom.IndividualComponents;
        }

        /// <summary>
        /// Constructs an approximated Steam Id based on a 32-bit Account Id. Since a full Steam Id includes more than just an Account Id, it is
        /// impossible to convert directly from Account Id to 64-bit Steam Id without making some assumptions. This constructor will assume the following.
        /// Universe: Public (1), Instance: Desktop (1), AccountType: Individual (1).
        /// </summary>
        /// <param name="accountId">32-bit Account Id portion of the Steam Id (the lowest 32-bits of the 64-bit Steam Id)</param>
        public SteamId(uint accountId)
        {
            AccountId = accountId;

            ulong steamId64 = (ulong)AccountId | 0x110000100000000;

            ConstructFromSteamId64(steamId64);

            ResolvedFrom = SteamIdResolvedFrom.AccountIdApproximation;
        }

        /// <summary>
        /// Constructs a Steam Id based on its 64-bit representation. The Universe, Account Type, Instance, and Account Id will be extracted from the 64-bit value.
        /// </summary>
        /// <param name="steamId64">The 64-bit Steam Id</param>
        public SteamId(ulong steamId64)
        {
            ConstructFromSteamId64(steamId64);

            ResolvedFrom = SteamIdResolvedFrom.SteamId64;
        }

        /// <summary>
        /// Constructs a Steam Id helper with deferred parsing and resolution because a fuzzy lookup will be needed. Follow up with the ResolveAsync method to
        /// asynchronously resolve the Steam Id information. This is typically used when you only know the users vanity URL name or don't know what type of Steam Id
        /// you have on hand.
        /// </summary>
        /// <param name="steamWebRequest">Required in the event that the Steam Web API is needed to resolve a Profile URL to a 64-bit Steam ID.</param>
        public SteamId(ISteamUser steamUser)
        {
            this.steamUser = steamUser;
        }

        /// <summary>
        /// Constructs a Steam Id by parsing the provided value. This will try to parse the value to a 64-bit Steam Id or a Steam Community Profile URL depending on the input.
        /// If a Profile URL is provided but is unable to be resolved to a 64-bit Steam ID, a VanityUrlNotResolvedException will be thrown. Network access may be required
        /// to receive a return value from this method in the event that the Steam Web API is required.
        /// </summary>
        /// <param name="value">Value to parse, can be a 64-bit Steam ID, a full Steam Community Profile URL, or the user's Steam Community Profile Name.</param>
        public async Task ResolveAsync(string value)
        {
            ulong steamId = 0;
            MatchCollection legacyCheckResult = null;
            MatchCollection modernCheckResult = null;

            // it's a legacy steam id in the format of STEAM_X:Y:Z
            if (IsLegacySteamId(value, out legacyCheckResult))
            {
                string universe = legacyCheckResult[0].Groups[1].Value;
                string authServer = legacyCheckResult[0].Groups[2].Value;
                string accountId = legacyCheckResult[0].Groups[3].Value;

                ConstructFromLegacySteamId(universe, authServer, accountId);

                ResolvedFrom = SteamIdResolvedFrom.LegacySteamId;
            }
            // it's a modern steam id in the format of [A:B:C:D]
            else if (IsModernSteamId(value, out modernCheckResult))
            {
                string accountTypeCharacter = modernCheckResult[0].Groups[1].Value;
                string universe = modernCheckResult[0].Groups[2].Value;
                string accountId = modernCheckResult[0].Groups[3].Value;
                string instance = string.Empty;
                if (modernCheckResult[0].Groups.Count == 5)
                {
                    instance = modernCheckResult[0].Groups[4].Value;
                }

                ConstructFromModernSteamId(accountTypeCharacter, instance, universe, accountId);

                ResolvedFrom = SteamIdResolvedFrom.ModernSteamId;
            }
            // it's a 64-bit steam id
            else if (ulong.TryParse(value, out steamId))
            {
                ConstructFromSteamId64(steamId);

                ResolvedFrom = SteamIdResolvedFrom.SteamId64;
            }
            // it's some other type of string, let's find out what it is
            else
            {
                // check if the caller entered a valid uri
                Uri uriResult;
                bool isUri = Uri.TryCreate(value, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == "http" || uriResult.Scheme == "https");

                try
                {
                    // the caller provided a uri
                    if (isUri)
                    {
                        // the caller provided a uri in the format we expected
                        if (uriResult.Segments.Length == 3)
                        {
                            string profileId = uriResult.Segments[2];

                            // if a user has a vanity name setup in their steam profile, the steam profile url will be in the format of: 
                            // http://steamcommunity.com/id/<vanity name>
                            // otherwise, the format will be:
                            // http://steamcommunity.com/profiles/<64-bit Steam ID>
                            if (uriResult.Segments[1] == "id/")
                            {
                                steamId = await ResolveSteamIdFromValueAsync(steamUser, profileId);
                                ConstructFromSteamId64(steamId);
                                ResolvedFrom = SteamIdResolvedFrom.SteamCommunityUri;
                            }
                            else if (uriResult.Segments[1] == "profiles/")
                            {
                                bool isSteamId64 = ulong.TryParse(profileId, out steamId);

                                if (isSteamId64)
                                {
                                    ConstructFromSteamId64(steamId);
                                    ResolvedFrom = SteamIdResolvedFrom.SteamCommunityUri;
                                }
                                else
                                {
                                    throw new InvalidSteamCommunityUriException(ErrorMessages.InvalidSteamCommunityUri);
                                }
                            }
                            else
                            {
                                throw new InvalidSteamCommunityUriException(ErrorMessages.InvalidSteamCommunityUri);
                            }
                        }
                        else
                        {
                            throw new InvalidSteamCommunityUriException(ErrorMessages.InvalidSteamCommunityUri);
                        }
                    }
                    else
                    {
                        // not a 64-bit Steam ID and not a uri, try to just resolve it as if it was a Steam Community Profile Name
                        steamId = await ResolveSteamIdFromValueAsync(steamUser, value);
                        ConstructFromSteamId64(steamId);
                        ResolvedFrom = SteamIdResolvedFrom.SteamCommunityProfileName;
                    }
                }
                catch (AggregateException ex)
                {
                    foreach (var innerEx in ex.InnerExceptions)
                    {
                        // throw the first specific exception that we expect
                        if (innerEx is VanityUrlNotResolvedException || innerEx is InvalidSteamCommunityUriException)
                        {
                            ExceptionDispatchInfo.Capture(innerEx).Throw();
                        }
                    }

                    // otherwise just throw the Aggregate and let the caller handle it
                    throw;
                }
            }
        }

        private void ConstructFromModernSteamId(string accountTypeCharacter, string instance, string universe, string accountId)
        {
            // set the account type based on the character
            char parsedAccountTypeCharacter = char.Parse(accountTypeCharacter);
            AccountType = GetAccountTypeFromCharacter(parsedAccountTypeCharacter);

            // set the default instance for the account type character
            if (parsedAccountTypeCharacter == GetCharacterFromAccountType(SteamAccountType.Individual))
            {
                Instance = SteamInstance.Desktop;
            }
            else { Instance = SteamInstance.All; }

            // override if an instance was provided
            if (!string.IsNullOrEmpty(instance))
            {
                Instance = (SteamInstance)uint.Parse(instance);
            }

            // set the universe
            Universe = (SteamUniverse)uint.Parse(universe);

            // set the account id
            AccountId = uint.Parse(accountId);
        }

        private void ConstructFromLegacySteamId(string universe, string authServer, string partialAccountId)
        {
            // setup the universe
            Universe = (SteamUniverse)GetUniverseFromLegacySteamId(universe);

            // setup the account id
            AccountId = GetAccountIdFromLegacySteamId(authServer, partialAccountId);

            // default the account type to individual since legacy steam doesn't have this in it
            AccountType = SteamAccountType.Individual;
        }

        /// <summary>
        /// Gets the correct Universe value from the passed string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private uint GetUniverseFromLegacySteamId(string value)
        {
            uint universe = uint.Parse(value);
            if (universe == 0) { universe = 1; }
            return universe;
        }

        /// <summary>
        /// Determines if the passed value is a Modern Steam Id format. Out parameter contains the matching results of the RegEx to test this.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="matches"></param>
        /// <returns></returns>
        private bool IsModernSteamId(string value, out MatchCollection matches)
        {
            Regex modernSteamIdCheck = new Regex("^\\[([AGMPCgcLTIUai]):([0-4]):([0-9]{1,10})(:([0-9]+))?\\]$");
            matches = modernSteamIdCheck.Matches(value);
            return matches.Count > 0;
        }

        /// <summary>
        /// Determines if the passed value is a Legacy Steam Id format. Out parameter contains the matching results of the RegEx to test this.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="matches"></param>
        /// <returns></returns>
        private bool IsLegacySteamId(string value, out MatchCollection matches)
        {
            Regex legacySteamIdCheck = new Regex("^STEAM_([0-4]):([0-1]):([0-9]{1,10})$");
            matches = legacySteamIdCheck.Matches(value);
            return matches.Count > 0;
        }

        /// <summary>
        /// Combines the two parameters to create a 32-bit Steam Account Id.
        /// </summary>
        /// <param name="authServer"></param>
        /// <param name="partialAccountId"></param>
        /// <returns></returns>
        private uint GetAccountIdFromLegacySteamId(string authServer, string partialAccountId)
        {
            uint authServerValue = uint.Parse(authServer);
            uint partialAccountIdValue = uint.Parse(partialAccountId);
            return (partialAccountIdValue << 1) | authServerValue;
        }

        /// <summary>
        /// Queries the Steam Web API for a 64-bit Steam ID based on a provided string value.
        /// </summary>
        /// <param name="steamUser"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static async Task<ulong> ResolveSteamIdFromValueAsync(ISteamUser steamUser, string value)
        {
            ulong steamId64 = 0;

            var steamId = await steamUser.ResolveVanityUrlAsync(value);
            steamId64 = steamId.Data;

            return steamId64;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns a Steam Id in the following format: STEAM_X:Y:Z where X is Universe, Y is lowest bit of Account Id, and Z is the highest 31-bits of Account Id.
        /// </summary>
        /// <returns>A Steam Id string such as STEAM_X:Y:Z</returns>
        public string ToLegacyFormat()
        {
            // X = universe
            int x = (int)Universe;

            // Z = highest 31 bits of Account Id
            uint z = (AccountId >> 1) & 0x7FFFFFFF;

            // Y = lowest bit of Account Id (always 0 or 1)
            uint y = AccountId & 1;

            return string.Format("STEAM_{0}:{1}:{2}", x, y, z);
        }

        /// <summary>
        /// Returns a Steam Id in the following format: [C:U:A] or [C:U:A:I] where C is Account Type character identifier, U is Universe, A is Account Id, and I is Instance Id.
        /// If there is no Instance Id, the value is omitted from the resulting string.
        /// </summary>
        /// <returns>A Steam Id string such as [C:U:A] or [C:U:A:I]</returns>
        public string ToModernFormat()
        {
            // C = a char representing the account type or a combination of account type + instance id
            char c = GetCharacterFromAccountType(AccountType);

            // U = universe
            int u = (int)Universe;

            // A = account id
            uint a = AccountId;

            return string.Format("[{0}:{1}:{2}]", c, u, a);
        }

        /// <summary>
        /// Returns the 64-bit representation of the Steam Id by combining the Universe, Account Id, Account Type, and Instance Id.
        /// </summary>
        /// <returns></returns>
        public ulong To64Bit()
        {
            // low 32 bits = account id
            ulong low32bits = AccountId;

            // next 20 bits = instance
            ulong next20bits = (ulong)Instance << 32;

            // next 4 bits = account type
            ulong next4bits = (ulong)AccountType << 52;

            // next 8 bits = universe
            ulong next8bits = (ulong)Universe << 56;

            return next8bits | next4bits | next20bits | low32bits;
        }

        /// <summary>
        /// Decompiles the 64-bit Steam Id into its 4 components based on bit manipulation
        /// </summary>
        /// <param name="steamId64">64-bit representation of the Steam Id</param>
        private void ConstructFromSteamId64(ulong steamId64)
        {
            // Account Id = low 32 bits
            AccountId = (uint)steamId64;

            // Instance Id = next 20 bits
            Instance = (SteamInstance)((uint)(steamId64 >> 32) & 0xFFFFF);

            // Account Type = 4 bits
            AccountType = (SteamAccountType)((uint)(steamId64 >> 52) & 0xF);

            // Universe = 8 bits
            Universe = (SteamUniverse)((uint)(steamId64 >> 56) & 0xFF);
        }

        /// <summary>
        /// Returns the account type identifier character based on the account type.
        /// </summary>
        /// <param name="accountType">A character identifier for the account type</param>
        /// <returns></returns>
        private char GetCharacterFromAccountType(SteamAccountType accountType)
        {
            if (accountType == SteamAccountType.Invalid) { return 'I'; }
            else if (accountType == SteamAccountType.Individual) { return 'U'; }
            else if (accountType == SteamAccountType.Multiseat) { return 'M'; }
            else if (accountType == SteamAccountType.GameServer) { return 'G'; }
            else if (accountType == SteamAccountType.AnonGameServer) { return 'A'; }
            else if (accountType == SteamAccountType.Pending) { return 'P'; }
            else if (accountType == SteamAccountType.ContentServer) { return 'C'; }
            else if (accountType == SteamAccountType.Clan) { return 'g'; }
            else if (accountType == SteamAccountType.Chat) { return 'T'; }
            else if (accountType == SteamAccountType.Chat_Clan) { return 'c'; }
            else if (accountType == SteamAccountType.Chat_Lobby) { return 'L'; }
            else if (accountType == SteamAccountType.AnonUser) { return 'a'; }
            else { return ' '; }
        }

        /// <summary>
        /// Returns the Steam Accoun Type associated with the passed character. Returns Account Type Invalid if the character doesn't match anything.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private SteamAccountType GetAccountTypeFromCharacter(char c)
        {
            if (c == 'I') { return SteamAccountType.Invalid; }
            else if (c == 'U') { return SteamAccountType.Individual; }
            else if (c == 'M') { return SteamAccountType.Multiseat; }
            else if (c == 'G') { return SteamAccountType.GameServer; }
            else if (c == 'A') { return SteamAccountType.AnonGameServer; }
            else if (c == 'P') { return SteamAccountType.Pending; }
            else if (c == 'C') { return SteamAccountType.ContentServer; }
            else if (c == 'g') { return SteamAccountType.Clan; }
            else if (c == 'T') { return SteamAccountType.Chat; }
            else if (c == 'c') { return SteamAccountType.Chat_Clan; }
            else if (c == 'L') { return SteamAccountType.Chat_Lobby; }
            else if (c == 'a') { return SteamAccountType.AnonUser; }
            else { return SteamAccountType.Invalid; }
        }

        #endregion Methods
    }
}