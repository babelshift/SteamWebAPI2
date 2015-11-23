using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public abstract class SteamWebInterface
    {
        private readonly SteamWebRequest steamWebRequest;
        private readonly string interfaceName;

        public SteamWebInterface(string steamWebApiKey, string interfaceName)
        {
            if(String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            Debug.Assert(!String.IsNullOrEmpty(interfaceName));

            this.interfaceName = interfaceName;
            this.steamWebRequest = new SteamWebRequest(steamWebApiKey);
        }

        internal async Task<T> CallMethodAsync<T>(string methodName, int version, IList<SteamWebRequestParameter> parameters = null)
        {
            Debug.Assert(!String.IsNullOrEmpty(methodName));
            Debug.Assert(version > 0);

            return await steamWebRequest.GetJsonAsync<T>(interfaceName, methodName, version, parameters);
        }

        #region Helpers

        internal void AddToParametersIfHasValue<T>(string name, T? value, IList<SteamWebRequestParameter> parameters) where T : struct
        {
            if (value.HasValue)
            {
                parameters.Add(new SteamWebRequestParameter(name, value.Value.ToString()));
            }
        }

        internal void AddToParametersIfHasValue<T>(string name, T value, IList<SteamWebRequestParameter> parameters)
        {
            if (value != null)
            {
                parameters.Add(new SteamWebRequestParameter(name, value.ToString()));
            }
        }
        
        internal void AddToParametersIfHasValue(string name, string value, IList<SteamWebRequestParameter> parameters)
        {
            if (!String.IsNullOrEmpty(value))
            {
                parameters.Add(new SteamWebRequestParameter(name, value));
            }
        }

        #endregion Helpers
    }
}
