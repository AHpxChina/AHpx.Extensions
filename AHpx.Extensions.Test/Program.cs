using System;
using System.IO;
using System.Threading.Tasks;
using AHpx.Extensions.IOExtensions;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json;

namespace AHpx.Extensions.Test
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var filePath = new FileInfo(@"C:\Users\ahpx\Desktop\test.txt");

            await filePath.WriteAllTextAsync("awkjdajwhd", false);
        }
    }
    
    class MyClass
    {
        public string Name { get; set; }
    }
}