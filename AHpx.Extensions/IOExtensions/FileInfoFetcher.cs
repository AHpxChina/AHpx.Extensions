using System.IO;
using System.Threading.Tasks;

namespace AHpx.Extensions.IOExtensions
{
    public static class FileInfoFetcher
    {
        public static string ReadAllText(this FileInfo info)
        {
            return File.ReadAllText(info.FullName);
        }
        
        public static async Task<string> ReadAllTextAsync(this FileInfo info)
        {
            using var reader = new StreamReader(info.OpenRead());

            return await reader.ReadToEndAsync();
        }

        public static void WriteAllText(this FileInfo info, string content, bool overwrite = true)
        {
            StreamWriter writer;
            if (!info.Exists)
            {
                 writer = new StreamWriter(info.Create());
            }
            else if (overwrite)
            {
                info.Delete();
                writer = new StreamWriter(info.Create());
            }
            else
            {
                throw new IOException("File already exist!");
            }

            using (writer)
            {
                writer.Write(content);
            }
        }

        public static async Task WriteAllTextAsync(this FileInfo info, string content, bool overwrite = true)
        {
            StreamWriter writer;
            if (!info.Exists)
            {
                writer = new StreamWriter(info.Create());
            }
            else if (overwrite)
            {
                info.Delete();
                writer = new StreamWriter(info.Create());
            }
            else
            {
                throw new IOException("File already exist!");
            }

            using (writer)
            {
                await writer.WriteAsync(content);
            }
        }
    }
}