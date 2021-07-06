using System;
using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.JsonExtensions
{
    public static class JsonFetcher
    {
        /// <summary>
        /// Fetch specify path in json
        /// </summary>
        /// <param name="s"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JToken FetchJToken(this string s, string path)
        {
            if (path.IsNullOrEmpty())
            {
                throw new Exception($"Path {path} of json can't be null or empty!");
            }
            
            if (s.IsNullOrEmpty())
            {
                throw new Exception("Json can't be null or empty!");
            }

            if (s.IsJsonString())
            {
                if (JToken.Parse(s) is JObject obj)
                {
                    return obj.SelectToken(path) ?? throw new Exception($"Path {path} doesn't exist!");
                }

                throw new Exception("JArray can't be fetch as a JObject!");
            }

            throw new Exception("Can't convert incoming string to JToken!");
        }

        /// <summary>
        /// Fetch specify path in json 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="path">x.xx.xxx</param>
        /// <returns></returns>
        public static string Fetch(this string s, string path)
        {
            return s.FetchJToken(path).ToString();
        }

        /// <summary>
        /// Fetch specify path in json 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JToken FetchJToken(this JToken token, string path)
        {
            return token.ToString().FetchJToken(path);
        }

        /// <summary>
        /// Fetch specify path in json 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Fetch(this JToken token, string path)
        {
            return token.ToString().Fetch(path);
        }
    }
}