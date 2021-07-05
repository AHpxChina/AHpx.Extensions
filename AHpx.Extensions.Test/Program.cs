using System;
using System.IO;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json;

namespace AHpx.Extensions.Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mycls = new
            {
                A1 = "awd",
                A2 = "awd",
                A3 = new
                {
                    B1 = "awd",
                    B2 = new[]
                    {
                        "awd",
                        "awd"
                    }
                }
            }.ToJsonString();

            Console.WriteLine(mycls.FetchJToken("A3.B2").IsJObjectOrThrow());
        }
    }
    
    class MyClass
    {
        public string Name { get; set; }
    }
}