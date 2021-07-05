using System.Collections.Generic;
using System.Diagnostics;

namespace AHpx.Extensions.Utils
{
    public static class ProcessUtilities
    {
        /// <summary>
        /// Construct a standard process object
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="arguments"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public static Process ConstructStandardProcess(string fileName, string arguments = null, string workingDirectory = null)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments ?? string.Empty,
                    WorkingDirectory = workingDirectory ?? string.Empty,
                    UseShellExecute = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            return process;
        }

        /// <summary>
        /// Get main window titles of specify process name
        /// </summary>
        /// <param name="processName">process name without extension name</param>
        /// <returns></returns>
        public static IEnumerable<string> GetWindowTitle(string processName)
        {
            var processes = Process.GetProcessesByName(processName);

            foreach (var process in processes)
            {
                yield return process.MainWindowTitle;
            }
        }

        /// <summary>
        /// Determine if process is running
        /// </summary>
        /// <param name="processName">process name without extension name</param>
        /// <returns></returns>
        public static bool IsProcessRunning(string processName)
        {
            return Process.GetProcessesByName(processName).Length > 0;
        }
    }
}