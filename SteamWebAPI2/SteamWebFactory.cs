using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebFactory
    {
        private string steamWebApiKey;

        public SteamWebFactory(string steamWebApiKey)
        {
            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            this.steamWebApiKey = steamWebApiKey;
        }

        public T Create<T>() where T : class
        {
            if(String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new InvalidOperationException("Steam Web API key is invalid or missing. Did you initialize it?");
            }

            return Activator.CreateInstance(typeof(T), steamWebApiKey) as T;
        }
    }
}
