using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringFilter
    {
        /// <summary>
        /// Determine if a string is not empty or null (and white space)
        /// </summary>
        /// <param name="s">Original string</param>
        /// <param name="checkWhitespace">Include white spaces or not</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string s, bool checkWhitespace = true)
        {
            var isWhitespace = string.IsNullOrWhiteSpace(s);
            var isNullOrEmpty = string.IsNullOrEmpty(s);

            return checkWhitespace 
                ? !isNullOrEmpty && !isWhitespace 
                : !isNullOrEmpty;
        }

        /// <summary>
        /// Determine if a string is empty or null (and white space)
        /// </summary>
        /// <param name="s">Original string</param>
        /// <param name="checkWhitespace">Include white spaces or not</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s, bool checkWhitespace = true)
        {
            var isWhitespace = string.IsNullOrWhiteSpace(s);
            var isNullOrEmpty = string.IsNullOrEmpty(s);

            return checkWhitespace 
                ? isNullOrEmpty || isWhitespace 
                : isNullOrEmpty;
        }

        /// <summary>
        /// Determine if a string is a integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInteger(this string s)
        {
            return long.TryParse(s, out _);
        }

        /// <summary>
        /// Determine if a string is not a integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotInteger(this string s) => !s.IsInteger();

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
                    var obj = JToken.Parse(s);
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
    }
}