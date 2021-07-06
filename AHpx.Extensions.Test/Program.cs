using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
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
            var url = new StringBuilder("https://login.live.com/oauth20_token.srf");
            url.Append("?client_id=00000000402b5328&");
            url.Append($"code=M.R3_BAY.ae002e00-c64a-c85f-6e21-7ea5ef72ebb9&");
            url.Append("grant_type=authorization_code&");
            url.Append("redirect_uri=https://login.live.com/oauth20_desktop.srf&");
            url.Append("scope=service::user.auth.xboxlive.com::MBI_SSL&");

            var response = await HttpUtilities.GetAsync(url.ToString(), "application/x-www-form-urlencoded");

            Console.WriteLine(await response.FetchContent());
        }
    }
}