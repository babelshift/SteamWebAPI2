using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class SteamNews : ISteamNews
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamNews(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamNews", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the news related to a specific app. This is similar to subscribing to various Valve RSS feeds.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="maxLength"></param>
        /// <param name="endDate"></param>
        /// <param name="count"></param>
        /// <param name="feeds"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamNewsResultModel>> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null, string feeds = null, string[] tags = null)
        {
            ulong? endDateUnixTimeStamp = null;

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(maxLength, "maxlength");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");
            parameters.AddIfHasValue(count, "count");
            parameters.AddIfHasValue(feeds, "feeds");
            parameters.AddIfHasValue(tags, "tags");

            var steamWebResponse = await steamWebInterface.GetAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new SteamNewsResultModel
                {
                    AppId = result.AppId,
                    NewsItems = result.NewsItems?.Select(n => new NewsItemModel
                    {
                        Gid = n.Gid,
                        Title = n.Title,
                        Url = n.Url,
                        IsExternalUrl = n.IsExternalUrl,
                        Author = n.Author,
                        Contents = n.Contents,
                        FeedLabel = n.FeedLabel,
                        Date = n.Date,
                        Feedname = n.Feedname,
                        Tags = n.Tags
                    }).ToList().AsReadOnly()
                };
            });
        }
    }
}