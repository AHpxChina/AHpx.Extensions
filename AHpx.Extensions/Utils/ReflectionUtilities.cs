using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AHpx.Extensions.StringExtensions;

namespace AHpx.Extensions.Utils
{
    public static class ReflectionUtilities
    {
        /// <summary>
        /// Get the version of current calling assembly
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Fail to to load entry assembly");
            
            var info = FileVersionInfo.GetVersionInfo(assembly.Location);

            return info.FileVersion;
        }

        /// <summary>
        /// Create default instance of type via no parameters constructor
        /// </summary>
        /// <param name="namespace">This parameter could be optional, the default value will be the name of entry assembly</param>
        /// <typeparam name="T">The ancestor type of instances</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetDefaultInstancesOf<T>(string @namespace = null) where T : class
        {
            var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Failed to load entry assembly");
            var types = new List<Type>();

            if (@namespace.IsNullOrEmpty())
                @namespace = assembly.GetName().Name;
            
            types
                .AddRange(assembly.GetTypes()
                .Where(x => x.FullName!.Contains(@namespace!)));

            var re = types
                .Where(type => !type.IsAbstract)
                .Select(type => Activator.CreateInstance(type) as T);

            return re.Where(x => x != null);
        }
    }
}