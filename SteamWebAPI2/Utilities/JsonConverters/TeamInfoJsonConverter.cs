using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;

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

                List<int> playerAccountIds = new List<int>();
                List<int> leagueIds = new List<int>();

                foreach (var teamProperty in team.Children<JProperty>())
                {
                    string value = teamProperty.Value.ToString();

                    if (teamProperty.Name == "team_id") { teamInfo.TeamId = Int32.Parse(value); }
                    if (teamProperty.Name == "name") { teamInfo.Name = value; }
                    if (teamProperty.Name == "tag") { teamInfo.Tag = value; }
                    if (teamProperty.Name == "time_created") { teamInfo.TimeCreated = Int64.Parse(value); }
                    if (teamProperty.Name == "rating") { teamInfo.Rating = value; }
                    if (teamProperty.Name == "logo") { teamInfo.Logo = Int64.Parse(value); }
                    if (teamProperty.Name == "logo_sponsor") { teamInfo.LogoSponsor = Int64.Parse(value); }
                    if (teamProperty.Name == "country_code") { teamInfo.CountryCode = value; }
                    if (teamProperty.Name == "url") { teamInfo.Url = value; }
                    if (teamProperty.Name == "games_played_with_current_roster") { teamInfo.GamesPlayedWithCurrentRoster = Int32.Parse(value); }
                    if (teamProperty.Name == "admin_account_id") { teamInfo.AdminAccountId = Int32.Parse(value); }
                    if (teamProperty.Name.StartsWith("player_"))
                    {
                        playerAccountIds.Add(Int32.Parse(value.ToString()));
                    }
                    if (teamProperty.Name.StartsWith("league_id_"))
                    {
                        leagueIds.Add(Int32.Parse(value.ToString()));
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
            return typeof(TeamInfo).IsAssignableFrom(objectType);
        }
    }
}