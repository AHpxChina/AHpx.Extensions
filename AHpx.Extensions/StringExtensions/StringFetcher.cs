using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringFetcher
    {
        /// <summary>
        /// Extension method of Path.GetFileName(WithoutExtension)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="withExtension"></param>
        /// <returns></returns>
        public static string FetchFileName(this string s, bool withExtension = true)
        {
            return withExtension ? Path.GetFileName(s) : Path.GetFileNameWithoutExtension(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JToken FetchJToken(this string s, string path)
        {
            if (path.IsNullOrEmpty())
            {
                throw new Exception("Path of json can't be null or empty!");
            }

            if (s.IsJsonString())
            {
                if (JToken.Parse(s) is JObject obj)
                {
                    return obj.SelectToken(path) ?? throw new Exception("Incoming path doesn't exist!");
                }

                throw new Exception("JArray can't be fetch as a JObject!");
            }

            throw new Exception("Can't convert incoming string to JToken!");
        }
    }
}