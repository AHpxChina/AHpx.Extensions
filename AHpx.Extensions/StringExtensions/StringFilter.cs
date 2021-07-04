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
    }
}