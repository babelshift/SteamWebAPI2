using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    internal class TeamInfoJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JArray a = JArray.Load(reader);

            List<TeamInfo> teamInfos = new List<TeamInfo>();

            foreach (var team in a.Children<JObject>())
            {
                TeamInfo teamInfo = new TeamInfo();

                List<uint> playerAccountIds = new List<uint>();
                List<uint> leagueIds = new List<uint>();

                foreach (var teamProperty in team.Children<JProperty>())
                {
                    string value = teamProperty.Value.ToString();

                    ulong longValue = 0;
                    uint uintValue = 0;
                    ulong ulongValue = 0;

                    uint.TryParse(value, out uintValue);
                    ulong.TryParse(value, out ulongValue);
                    ulong.TryParse(value, out longValue);

                    if (teamProperty.Name == "team_id") { teamInfo.TeamId = uintValue; }
                    if (teamProperty.Name == "name") { teamInfo.Name = value; }
                    if (teamProperty.Name == "tag") { teamInfo.Tag = value; }
                    if (teamProperty.Name == "time_created") { teamInfo.TimeCreated = longValue; }
                    if (teamProperty.Name == "rating") { teamInfo.Rating = value; }
                    if (teamProperty.Name == "logo") { teamInfo.Logo = ulongValue; }
                    if (teamProperty.Name == "logo_sponsor") { teamInfo.LogoSponsor = ulongValue; }
                    if (teamProperty.Name == "country_code") { teamInfo.CountryCode = value; }
                    if (teamProperty.Name == "url") { teamInfo.Url = value; }
                    if (teamProperty.Name == "games_played_with_current_roster") { teamInfo.GamesPlayedWithCurrentRoster = uintValue; }
                    if (teamProperty.Name == "admin_account_id") { teamInfo.AdminAccountId = uintValue; }
                    if (teamProperty.Name.StartsWith("player_"))
                    {
                        playerAccountIds.Add(uintValue);
                    }
                    if (teamProperty.Name.StartsWith("league_id_"))
                    {
                        leagueIds.Add(uintValue);
                    }
                }

                teamInfo.PlayerIds = playerAccountIds;
                teamInfo.LeagueIds = leagueIds;
                teamInfos.Add(teamInfo);
            }

            return teamInfos;
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TeamInfo).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}