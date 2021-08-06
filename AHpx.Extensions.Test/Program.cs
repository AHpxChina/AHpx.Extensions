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
        private static void Main(string[] args)
        {
            var instances = ReflectionUtilities.GetDefaultInstancesOf<ITest>();

            foreach (var instance in instances)
            {
                instance.Test();
            }
        }
    }
}