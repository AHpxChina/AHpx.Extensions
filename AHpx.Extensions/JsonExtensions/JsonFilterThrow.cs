using System;
using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.JsonExtensions
{
    public static class JsonFilterThrow
    {
        /// <summary>
        /// Determine if a string is a json string or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsJsonStringOrThrow(this string s, Exception exception)
        {
            return s.IsJsonString() ? s : throw exception;
        }

        /// <summary>
        /// Determine if a string is a json string or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Exception message</param>
        /// <returns></returns>
        public static string IsJsonStringOrThrow(this string s, string exception = null)
        {
            return s.IsJsonStringOrThrow(new Exception(exception.IsNullOrEmpty() ? $"{s} is not a valid json!" : exception));
        }

        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JObject IsJObjectOrThrow(this string s, Exception exception)
        {
            return s.IsJObject() ? JObject.Parse(s) : throw exception;
        }

        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Exception message</param>
        /// <returns></returns>
        public static JObject IsJObjectOrThrow(this string s, string exception = null)
        {
            return s.IsJObjectOrThrow(new Exception(exception.IsNullOrEmpty() ? $"{s} is not a valid JObject!" : exception));
        }

        public static JArray IsJArrayOrThrow(this string s, Exception exception)
        {
            return s.IsJArray() ? JArray.Parse(s) : throw exception;
        }
        
        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Exception message</param>
        /// <returns></returns>
        public static JArray IsJArrayOrThrow(this string s, string exception = null)
        {
            return s.IsJArrayOrThrow(new Exception(exception.IsNullOrEmpty() ? $"{s} valid JArray!" : exception));
        }
        
        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JObject IsJObjectOrThrow(this JToken s, Exception exception)
        {
            return s.IsJObject() ? s as JObject : throw exception;
        }

        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Exception message</param>
        /// <returns></returns>
        public static JObject IsJObjectOrThrow(this JToken s, string exception = null)
        {
            return s.IsJObjectOrThrow(new Exception(exception.IsNullOrEmpty() ? $"{s} a valid JObject!" : exception));
        }

        public static JArray IsJArrayOrThrow(this JToken s, Exception exception)
        {
            return s.IsJArray() ? s as JArray : throw exception;
        }
        
        /// <summary>
        /// Determine if a string is a json or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Exception message</param>
        /// <returns></returns>
        public static JArray IsJArrayOrThrow(this JToken s, string exception = null)
        {
            return s.IsJArrayOrThrow(new Exception(exception.IsNullOrEmpty() ? $"{s} a valid JArray!" : exception));
        }
    }
}