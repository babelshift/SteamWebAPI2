using System;
using System.Collections.Generic;

namespace Steam.Models.GameServers
{
    public class AccountListModel
    {
        public IEnumerable<AccountServerModel> Servers { get; set; }

        public bool IsBanned { get; set; }

        /// <summary>Not sure if this should be a DateTime or bool. Can't find
        /// documentation on what this field indicates.
        /// </summary>
        public uint Expires { get; set; }

        /// <summary>Steam ID of the account holder that created the game server account.
        /// </summary>
        public ulong Actor { get; set; }

        /// <summary>Not sure what this indicates. After creating a game server account,
        /// I expected to see a time stamp here, but it returns 0 instead.
        /// </summary>
        public DateTime? LastActionTime { get; set; }
    }
}