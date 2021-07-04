using System;
using AHpx.Extensions.StringExtensions;

namespace AHpx.Extensions.Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!".IsNotNullOrEmpty());
            Console.WriteLine("".IsNotNullOrEmpty());
            Console.WriteLine(" ".IsNullOrEmpty());
        }
    }
}