using System.Diagnostics;
using System.Reflection;

namespace AHpx.Extensions.Utils
{
    public static class ReflectionUtilities
    {
        public static string GetAssemblyVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = FileVersionInfo.GetVersionInfo(assembly.Location);

            return info.FileVersion;
        }
    }
}