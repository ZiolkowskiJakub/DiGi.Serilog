using DiGi.Serilog.Classes;

namespace DiGi.Serilog
{
    public static partial class Settings
    {
        public static LoggerManager LoggerManager { get; } = new LoggerManager();
    }
}