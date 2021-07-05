using System.IO;
using AHpx.Extensions.StringExtensions;

namespace AHpx.Extensions.IOExtensions
{
    public static class DirectoryExtensions
    {
        public static DirectoryInfo GetSubDirectory(this DirectoryInfo info, string path)
        {
            return new($"{info.FullName.TrimEnd(Path.DirectorySeparatorChar)}/{path}".ConstructPath());
        }

        public static FileInfo GetSubFile(this DirectoryInfo info, string path)
        {
            return new($"{info.FullName.TrimEnd(Path.DirectorySeparatorChar)}/{path}".ConstructPath());
        }
    }
}