using DiGi.Serilog.Classes;

namespace DiGi.Serilog
{
    public static partial class Settings
    {
        /// <summary>
        /// Gets the logger manager instance.
        /// </summary>
        public static LoggerManager LoggerManager { get; } = new LoggerManager();
    }
}