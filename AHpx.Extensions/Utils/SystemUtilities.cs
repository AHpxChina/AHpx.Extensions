using System;

namespace AHpx.Extensions.Utils
{
    public static class SystemUtilities
    {
        /// <summary>
        /// Determine current running system bit type
        /// </summary>
        /// <returns>64 or 32</returns>
        public static string GetSystemBitType()
        {
            return Environment.Is64BitOperatingSystem ? "64" : "32";
        }
    }
}