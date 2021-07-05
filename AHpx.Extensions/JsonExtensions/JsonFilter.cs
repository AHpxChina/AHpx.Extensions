using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.JsonExtensions
{
    public static class JsonFilter
    {
        /// <summary>
        /// Determine if a string is a json string (JObject or JArray)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsJsonString(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return false;
            }
            
            s = s.Trim();
            if (s.StartsWith("{") && s.EndsWith("}") || //For object
                s.StartsWith("[") && s.EndsWith("]")) //For array
            {
                try
                {
                    _ = JToken.Parse(s);
                    return true;
                }
                catch //some other exception
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if a string is not a json string (JObject or JArray)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotJsonString(this string s) => !s.IsJsonString();

        /// <summary>
        /// Determine if a string is a JObject or not
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsJObject(this string s)
        {
            s = s.IsJsonStringOrThrow();

            var token = JToken.Parse(s);

            return token is JObject;
        }
    }
}