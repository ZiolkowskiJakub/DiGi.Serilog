using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DiGi.Serilog.Classes
{
    public class LoggerManager
    {
        // Using a more modern dictionary initialization
        private readonly Dictionary<string, Logger> loggers = [];

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