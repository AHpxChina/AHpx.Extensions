using System;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringFilterThrow
    {
        /// <summary>
        /// Determine if a string is empty, throw an exception if it is empty or null,
        /// otherwise return the string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception"></param>
        /// <param name="checkWhitespace"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string IsNotNullOrEmptyThrow(this string s, Exception exception,
            bool checkWhitespace = true)
        {
            var result = s.IsNotNullOrEmpty(checkWhitespace);

            return result
                ? s
                : throw (exception ?? new ArgumentNullException($"Parameter {nameof(s)} is null or empty!"));
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
        public static string IsNotNullOrEmptyThrow(this string s, string exception = null, bool checkWhitespace = true)
        {
            return s.IsNotNullOrEmptyThrow(new Exception(exception), checkWhitespace);
        }

        /// <summary>
        /// Determine if a string is an integer or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Custom exception</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsIntegerOrThrow(this string s, Exception exception)
        {
            return s.IsInteger()
                ? s
                : throw (exception ?? new ArgumentException("Incoming parameter is not an integer!"));
        }

        /// <summary>
        /// Determine if a string is an integer or throw exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="exception">Custom exception message, optional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsIntegerOrThrow(this string s, string exception = null)
        {
            return s.IsNotNullOrEmptyThrow(new Exception(exception.IsNullOrEmpty()
                ? "Incoming parameter is not an integer!"
                : exception));
        }
    }
}