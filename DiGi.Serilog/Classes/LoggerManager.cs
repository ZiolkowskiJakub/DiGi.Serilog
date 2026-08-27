using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;

namespace DiGi.Serilog.Classes
{
    /// <summary>
    /// Manages the creation and retrieval of logger instances.
    /// <para>By default one application writes one log. The directory is the one the application was launched from, so every assembly it loads - whichever repository each was built in - reports into the same file. Deriving the log location from the calling assembly's own location used to split one application's output across files whenever its assemblies were deployed to different folders, and an assembly bundled into a single-file application reported no location at all, which silently disabled logging.</para>
    /// <para>When <see cref="RoutePerAssembly"/> is enabled, an assembly that has a resolvable location writes its log beside itself instead. A modular host that loads extensions from sub-folders uses this so every extension keeps its own <c>logs</c> folder while the host keeps the one beside the application. The explicit <see cref="Directory"/> override always wins.</para>
    /// </summary>
    public class LoggerManager
    {
        // A concurrent cache: racing first-time requests must resolve to one Logger per path, which a
        // plain dictionary could not guarantee - racing writers corrupted its internal state and a
        // worker could spin forever inside it.
        private readonly ConcurrentDictionary<string, Logger> loggers = [];

        /// <summary>
        /// Gets or sets the directory the <c>logs</c> folder is created in. When null the directory the application was launched from is used, or the requesting assembly's own directory when <see cref="RoutePerAssembly"/> is enabled.
        /// </summary>
        public string? Directory { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether a logger writes into the directory of the assembly requesting it instead of the directory the application was launched from. Defaults to false, so one application writes one log no matter where its assemblies were deployed.
        /// </summary>
        public bool RoutePerAssembly { get; set; } = false;

        /// <summary>
        /// Retrieves an existing logger for the specified assembly or creates a new one if requested.
        /// <para>Concurrent first-time requests for the same path resolve to a single <see cref="Logger"/>, so controller code logging in parallel never races on the cache.</para>
        /// </summary>
        /// <param name="assembly">The assembly asking for the logger. With <see cref="RoutePerAssembly"/> enabled and a resolvable location it also decides where the log is written; otherwise it is retained so a caller can be identified.</param>
        /// <param name="create">A value indicating whether a new logger should be created if an existing one is not found. Defaults to true.</param>
        /// <returns>The <see cref="Logger"/> instance, or <c>null</c> if the assembly is null, the path cannot be determined, or creation is disabled and no logger exists.</returns>
        public Logger? GetLogger(Assembly? assembly, bool create = true)
        {
            if (assembly is null)
            {
                return null;
            }

            string? baseDirectory = ResolveBaseDirectory(Directory, RoutePerAssembly, assembly.Location);
            if (string.IsNullOrEmpty(baseDirectory))
            {
                return null;
            }

            string logDirectory = Path.Combine(baseDirectory, Constants.Name.Directory.Logs);
            string logPath = Path.Combine(logDirectory, $"{Constants.Name.File.Log}.txt");

            if (!create)
            {
                return loggers.TryGetValue(logPath, out Logger? existingLogger) ? existingLogger : null;
            }

            // GetOrAdd is atomic: racing creators may build more than one candidate, but only one is
            // ever cached or returned, and an unused Serilog file sink opens no file until first use.
            return loggers.GetOrAdd(logPath, _ => CreateLogger(logPath));
        }

        // Testable seam: an assembly bundled into a single-file application reports an empty location,
        // which must fall back to the directory the application was launched from.
        internal static string? ResolveBaseDirectory(string? directory, bool routePerAssembly, string? assemblyLocation)
        {
            if (!string.IsNullOrWhiteSpace(directory))
            {
                return directory;
            }

            if (routePerAssembly && !string.IsNullOrWhiteSpace(assemblyLocation))
            {
                return Path.GetDirectoryName(assemblyLocation);
            }

            return AppContext.BaseDirectory;
        }

        private static Logger CreateLogger(string logPath)
        {
#if DEBUG
            LogEventLevel minimumLevel = LogEventLevel.Debug;
#else
            LogEventLevel minimumLevel = LogEventLevel.Information;
#endif

            return new LoggerConfiguration()
                .MinimumLevel.Is(minimumLevel)
                .WriteTo.File(
                    path: logPath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
