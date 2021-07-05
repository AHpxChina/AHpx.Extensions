using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
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

        public static async Task<string> FetchContent(this HttpResponseMessage message)
        {
            return await message.Content.ReadAsStringAsync();
        }
    }
}