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
    }
}