using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
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
            Console.WriteLine(ProcessUtilities.IsProcessRunning("javaw"));
            Console.WriteLine(ProcessUtilities.IsProcessRunning("qq"));
        }
    }
    
    class MyClass
    {
        public string Name { get; set; }
    }
}