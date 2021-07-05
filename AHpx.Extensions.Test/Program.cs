using System;
using AHpx.Extensions.StringExtensions;

namespace AHpx.Extensions.Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("".IsNotNullOrEmptyThrow(new Exception("This is a custom exception")));
        }
    }
}