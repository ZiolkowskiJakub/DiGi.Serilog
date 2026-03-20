using Serilog.Core;
using System;
using System.Reflection;

namespace DiGi.Serilog
{
    public static partial class Modify
    {
        public static bool Log(this Assembly? assembly, Enums.LogEventLevel logEventLevel, string? message, params object[] parameters)
        {
            if (message is null || assembly is null)
            {
                return false;
            }

            Logger? logger = Settings.LoggerManager?.GetLogger(assembly);
            if (logger is null)
            {
                return false;
            }

            switch (logEventLevel)
            {
                case Enums.LogEventLevel.Verbose:
                    logger.Verbose(message, parameters);
                    return true;

                case Enums.LogEventLevel.Debug:
                    logger.Debug(message, parameters);
                    return true;

                case Enums.LogEventLevel.Information:
                    logger.Information(message, parameters);
                    return true;

                case Enums.LogEventLevel.Warning:
                    logger.Warning(message, parameters);
                    return true;

                case Enums.LogEventLevel.Error:
                    logger.Error(message, parameters);
                    return true;

                case Enums.LogEventLevel.Fatal:
                    logger.Fatal(message, parameters);
                    return true;
            }

            return false;
        }

        public static bool Log(this Assembly? assembly, string? message, params object[] parameters)
        {
            return Log(assembly, Enums.LogEventLevel.Information, message, parameters);
        }

        public static bool Log(this Assembly? assembly, Exception? exception, string? message)
        {
            if (message is null || assembly is null)
            {
                return false;
            }

            Logger? logger = Settings.LoggerManager?.GetLogger(assembly);
            if (logger is null)
            {
                return false;
            }

            logger.Error(exception, message);
            return true;
        }

        public static bool Log(Enums.LogEventLevel logEventLevel, string? message, params object[] parameters)
        {
            return Log(Assembly.GetCallingAssembly(), logEventLevel, message, parameters);
        }

        public static bool Log(string? message, params object[] parameters)
        {
            return Log(Assembly.GetCallingAssembly(), message, parameters);
        }

        public static bool Log(Exception? exception, string? message, params object[] parameters)
        {
            return Log(Assembly.GetCallingAssembly(), message, parameters);
        }
    }
}