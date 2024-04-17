using NLog;

namespace Diplom_Pokrovskaya.Core
{
    public class NLogConfig
    {
        public void Config()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logConsole = new NLog.Targets.ConsoleTarget("logconsole");
            var logFile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "file.txt",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${threadid}|${message}|${exception:format=tostring}"
            };

            // Rules for mapping loggers to targets  
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logFile);

            // Apply config
            LogManager.Configuration = config;
        }
    }
}
