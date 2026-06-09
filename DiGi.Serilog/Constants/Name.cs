namespace DiGi.Serilog.Constants
{
    /// <summary>
    /// Provides a centralized location for naming constants used within the Serilog configuration.
    /// </summary>
    public static class Name
    {
        /// <summary>
        /// Contains constant values related to directory names.
        /// </summary>
        public static class Directory
        {
            /// <summary>
            /// The default name of the directory where log files are stored.
            /// </summary>
            public const string Logs = "logs";
        }

        /// <summary>
        /// Contains constant values related to file naming conventions.
        /// </summary>
        public static class File
        {
            /// <summary>
            /// The prefix used for log filenames.
            /// </summary>
            public const string Log = "log-";
        }
    }
}