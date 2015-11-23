using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class UserGroup
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        public Uri Avatar { get; set; }
        public Uri AvatarMedium { get; set; }
        public Uri AvatarFull { get; set; }
        public int MemberCount { get; set; }
        public int MemberChatCount { get; set; }
        public int MemberGameCount { get; set; }
        public int MemberOnlineCount { get; set; }
    }
}
