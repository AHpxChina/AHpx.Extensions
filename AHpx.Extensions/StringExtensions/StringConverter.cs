using System;
using System.IO;
using AHpx.Extensions.JsonExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringConverter
    {
        /// <summary>
        /// Convert a string to JObject. Exception will be occurred if it not. 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string s)
        {
            s = s.IsNotNullOrEmptyThrow("A null or empty string can't be convert to json!")
                .IsJsonStringOrThrow("Incoming string is not a valid json string!");
            
            return JObject.Parse(s);
        }

        /// <summary>
        /// Serialize an object to json string, null value will be ignored
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToJsonString<T>(this T t)
        {
            try
            {
                return JsonConvert.SerializeObject(t, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception e)
            {
                throw new Exception("Incoming Type parameter can't be serialize to json", e);
            }
        }

        /// <summary>
        /// Construct certain path for the current operating system
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ConstructPath(this string s, char separator = '/')
        {
            return s.Replace('/', Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Convert string to int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt32(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        /// Convert string to long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToInt64(this string s)
        {
            return long.Parse(s);
        }
    }
}