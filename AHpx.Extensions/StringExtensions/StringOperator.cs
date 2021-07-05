using System;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringOperator
    {
        /// <summary>
        /// Empty specify content in string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Empty(this string s, string target)
        {
            return s.Replace(target, string.Empty);
        }

        /// <summary>
        /// Empty all the linebreak symbol in string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EmptyLinebreak(this string s)
        {
            return s.Empty(Environment.NewLine);
        }
    }
}