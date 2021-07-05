using System.Diagnostics;
using System.Threading.Tasks;

namespace AHpx.Extensions.ProcessExtensions
{
    public static class ProcessFetcher
    {
        public static string ReadOutputLine(this Process process)
        {
            return process.StandardOutput.ReadLine();
        }

        public static async Task<string> ReadOutputLineAsync(this Process process)
        {
            return await process.StandardOutput.ReadLineAsync();
        }
    }
}