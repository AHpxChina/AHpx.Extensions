using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AHpx.Extensions.IOExtensions;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using AHpx.Extensions.Utils;
using Newtonsoft.Json;

namespace AHpx.Extensions.Test
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var response = await HttpUtilities.PostJsonAsync("https://httpbin.org/post", new
            {
                Test = "awd"
            }.ToJsonString(), new[]
            {
                ("AHpx", "zax"),
                ("AHpxx", "aax"),
                ("Content-Type", "application/yaml")
            });

            var content = await response.FetchContent();

            Console.WriteLine(content);
        }
    }
}