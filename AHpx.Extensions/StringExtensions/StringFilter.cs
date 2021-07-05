using System;

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
        /// Determine if a string is empty, throw an exception if it is empty or null,
        /// otherwise return the string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception"></param>
        /// <param name="checkWhitespace"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string IsNotNullOrEmptyThrow(this string s, Exception exception = null, bool checkWhitespace = true)
        {
            var result = s.IsNotNullOrEmpty(checkWhitespace);

            return result
                ? s
                : throw (exception ?? new ArgumentNullException($"Parameter {nameof(s)} is null or empty!"));
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
    }
}