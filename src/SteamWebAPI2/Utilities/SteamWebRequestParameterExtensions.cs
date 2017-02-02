using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Utilities
{
    internal static class SteamWebRequestParameterExtensions
    {
        /// <summary>
        /// Checks if the passed nullable value has a value. If it does, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <typeparam name="T">Type of the value to check</typeparam>
        /// <param name="value">Nullable value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="list">List of web request parameters that will be used in the building of the request URL</param>
        internal static void AddIfHasValue<T>(this IList<SteamWebRequestParameter> list, T? value, string name) where T : struct
        {
            if (value.HasValue)
            {
                list.Add(new SteamWebRequestParameter(name, value.Value.ToString()));
            }
        }

        /// <summary>
        /// Checks if the passed value is not null. If it is not null, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <typeparam name="T">Type of the value to check</typeparam>
        /// <param name="value">Value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="list">List of web request parameters that will be used in the building of the request URL</param>
        internal static void AddIfHasValue<T>(this IList<SteamWebRequestParameter> list, T value, string name)
        {
            if (value != null)
            {
                list.Add(new SteamWebRequestParameter(name, value.ToString()));
            }
        }

        /// <summary>
        /// Checks if the passed string value is not null or empty. If it is not null or empty, it is appended to the parameter list as a key/value pair with "name" as the key.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="name">Name of the key that will be used if the value is appended to the parameter list</param>
        /// <param name="list">List of web request parameters that will be used in the building of the request URL</param>
        internal static void AddIfHasValue(this IList<SteamWebRequestParameter> list, string value, string name)
        {
            if (!String.IsNullOrEmpty(value))
            {
                list.Add(new SteamWebRequestParameter(name, value));
            }
        }
    }
}