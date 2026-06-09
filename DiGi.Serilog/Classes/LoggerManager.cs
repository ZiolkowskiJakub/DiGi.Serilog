using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DiGi.Serilog.Classes
{
    /// <summary>
    /// Manages the creation and retrieval of logger instances associated with specific assemblies.
    /// </summary>
    public class LoggerManager
    {
        // Using a more modern dictionary initialization
        private readonly Dictionary<string, Logger> loggers = [];

        /// <summary>
        /// Retrieves an existing logger for the specified assembly or creates a new one if requested.
        /// </summary>
        /// <param name="assembly">The assembly used to determine the directory and path for the log file.</param>
        /// <param name="create">A value indicating whether a new logger should be created if an existing one is not found. Defaults to true.</param>
        /// <returns>The <see cref="Logger"/> instance associated with the assembly, or <c>null</c> if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists.</returns>
        public Logger? GetLogger(Assembly? assembly, bool create = true)
        {
            if (assembly is null)
            {
                return null;
            }

            // Optimization: Get directory once and validate
            string? assemblyLocation = assembly.Location;
            if (string.IsNullOrEmpty(assemblyLocation))
            {
                return null;
            }

            string? baseDirectory = Path.GetDirectoryName(assemblyLocation);
            if (baseDirectory is null)
            {
                return null;
            }

            string logDirectory = Path.Combine(baseDirectory, Constants.Name.Directory.Logs);
            string logPath = Path.Combine(logDirectory, $"{Constants.Name.File.Log}.txt");

            // Check if logger already exists for this path
            if (loggers.TryGetValue(logPath, out Logger? existingLogger))
            {
                return existingLogger;
            }

            if (!create)
            {
                return null;
            }

#if DEBUG
            LogEventLevel minimumLevel = LogEventLevel.Debug;
#else
            LogEventLevel minimumLevel = LogEventLevel.Information;
#endif

            // Build new logger instance
            Logger newLogger = new LoggerConfiguration()
                .MinimumLevel.Is(minimumLevel)
                .WriteTo.File(
                    path: logPath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            loggers[logPath] = newLogger;

            return newLogger;
        }
    }
}