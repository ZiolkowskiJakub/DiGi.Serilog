using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DiGi.Serilog.Classes
{
    /// <summary>
    /// Manages the creation and retrieval of logger instances.
    /// <para>One application writes one log. The directory is the one the application was launched from, so every assembly it loads - whichever repository each was built in - reports into the same file.</para>
    /// </summary>
    public class LoggerManager
    {
        // Using a more modern dictionary initialization
        private readonly Dictionary<string, Logger> loggers = [];

        /// <summary>
        /// Gets or sets the directory the <c>logs</c> folder is created in. When null the directory the application was launched from is used.
        /// </summary>
        public string? Directory { get; set; } = null;

        /// <summary>
        /// Retrieves an existing logger for the specified assembly or creates a new one if requested.
        /// <para>The log location does not depend on the assembly. It used to be derived from the calling assembly's own location, which put a task's report beside its own library rather than beside the application: two tasks of the same application logged to two different files whenever their libraries were deployed to different folders, and one of them looked as though it had produced no output at all. An assembly bundled into a single-file application made it worse by reporting no location, which silently disabled logging altogether.</para>
        /// </summary>
        /// <param name="assembly">The assembly asking for the logger. Retained so a caller can be identified, but it no longer decides where the log is written.</param>
        /// <param name="create">A value indicating whether a new logger should be created if an existing one is not found. Defaults to true.</param>
        /// <returns>The <see cref="Logger"/> instance, or <c>null</c> if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists.</returns>
        public Logger? GetLogger(Assembly? assembly, bool create = true)
        {
            if (assembly is null)
            {
                return null;
            }

            string? baseDirectory = string.IsNullOrWhiteSpace(Directory) ? AppContext.BaseDirectory : Directory;
            if (string.IsNullOrEmpty(baseDirectory))
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