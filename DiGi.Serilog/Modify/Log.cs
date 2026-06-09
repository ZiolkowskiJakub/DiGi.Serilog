using Serilog.Core;
using System;
using System.Reflection;

namespace DiGi.Serilog
{
    public static partial class Modify
    {
        /// <summary>
        /// Logs a message with a specified event level for the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to associate with the logger.</param>
        /// <param name="logEventLevel">The severity level of the log event.</param>
        /// <param name="message">The message template to be logged.</param>
        /// <param name="parameters">The arguments to be formatted into the message template.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
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

        /// <summary>
        /// Logs an information message for the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to associate with the logger.</param>
        /// <param name="message">The message template to be logged.</param>
        /// <param name="parameters">The arguments to be formatted into the message template.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
        public static bool Log(this Assembly? assembly, string? message, params object[] parameters)
        {
            return Log(assembly, Enums.LogEventLevel.Information, message, parameters);
        }

        /// <summary>
        /// Logs an error message and a corresponding exception for the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to associate with the logger.</param>
        /// <param name="exception">The exception to be logged.</param>
        /// <param name="message">The error message to be logged.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
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

        /// <summary>
        /// Logs a message with a specified event level using the calling assembly.
        /// </summary>
        /// <param name="logEventLevel">The severity level of the log event.</param>
        /// <param name="message">The message template to be logged.</param>
        /// <param name="parameters">The arguments to be formatted into the message template.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
        public static bool Log(Enums.LogEventLevel logEventLevel, string? message, params object[] parameters)
        {
            return Log(Assembly.GetCallingAssembly(), logEventLevel, message, parameters);
        }

        /// <summary>
        /// Logs an information message using the calling assembly.
        /// </summary>
        /// <param name="message">The message template to be logged.</param>
        /// <param name="parameters">The arguments to be formatted into the message template.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
        public static bool Log(string? message, params object[] parameters)
        {
            return Log(Assembly.GetCallingAssembly(), message, parameters);
        }

        /// <summary>
        /// Logs an error message and a corresponding exception using the calling assembly.
        /// </summary>
        /// <param name="exception">The exception to be logged.</param>
        /// <param name="message">The error message to be logged.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
        public static bool Log(Exception? exception, string? message)
        {
            if (exception is null && message is null)
            {
                return false;
            }

            Logger? logger = Settings.LoggerManager?.GetLogger(Assembly.GetCallingAssembly());
            if (logger is null)
            {
                return false;
            }

            if (exception is null)
            {
                logger.Error(message!);
                return true;
            }

            logger.Error(exception, message!);
            return true;
        }

        /// <summary>
        /// Logs an error message with arguments and a corresponding exception using the calling assembly.
        /// </summary>
        /// <param name="exception">The exception to be logged.</param>
        /// <param name="message">The message template to be logged.</param>
        /// <param name="parameters">The arguments to be formatted into the message template.</param>
        /// <returns>True if the logging operation was successful; otherwise, false.</returns>
        public static bool Log(Exception? exception, string? message, params object[] parameters)
        {
            if (exception is null && message is null)
            {
                return false;
            }

            Logger? logger = Settings.LoggerManager?.GetLogger(Assembly.GetCallingAssembly());
            if (logger is null)
            {
                return false;
            }

            if (exception is null)
            {
                logger.Error(message!);
                return true;
            }

            logger.Error(exception, message!, parameters);
            return true;
        }
    }
}