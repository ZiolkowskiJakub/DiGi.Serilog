namespace DiGi.Serilog.Enums
{
    /// <summary>
    /// Defines the severity levels for log events.
    /// </summary>
    public enum LogEventLevel
    {
        /// <summary>
        /// The most detailed level, typically used for tracing and deep diagnostic information.
        /// </summary>
        Verbose,

        /// <summary>
        /// Detailed information useful during development to diagnose issues.
        /// </summary>
        Debug,

        /// <summary>
        /// General information about the application's operation and flow.
        /// </summary>
        Information,

        /// <summary>
        /// Indicates a potential problem that does not currently stop the application but may require attention.
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates an error that occurred during a specific operation, which may be recoverable.
        /// </summary>
        Error,

        /// <summary>
        /// Indicates a critical failure that causes the application to terminate or enter an unusable state.
        /// </summary>
        Fatal
    }
}