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
            var filePath = new DirectoryInfo(@"C:\Users\ahpx\Desktop");

            Console.WriteLine(filePath.GetSubFile("text.txt"));
            Console.WriteLine(filePath.GetSubDirectory("Hypixel").Exists);
        }
    }
    
    class MyClass
    {
        public string Name { get; set; }
    }
}