using Discord;
using NLog;
using System;

namespace NekoBot.Infrastructure
{
    public class NekoLog
    {
        private static readonly Logger logger = LogManager.GetLogger("NekoBot");

        public static void Log(LogMessage msg)
        {
            Log(logger, msg);
        }

        public static void Log(Logger nLogger, LogMessage msg)
        {
            switch (msg.Severity)
            {
                case LogSeverity.Verbose:
                    nLogger.Trace($" [{msg.Source}] {msg.Message}");
                    break;
                case LogSeverity.Info:
                    nLogger.Info($" [{msg.Source}] {msg.Message}");
                    break;
                case LogSeverity.Debug:
                    nLogger.Debug($" [{msg.Source}] {msg.Message}");
                    break;
                case LogSeverity.Warning:
                    nLogger.Warn($" [{msg.Source}] {msg.Message}");
                    break;
                case LogSeverity.Error:
                    nLogger.Error($" [{msg.Source}] {msg.Message}");
                    break;
                case LogSeverity.Critical:
                    nLogger.Fatal($" [{msg.Source}] {msg.Message}");
                    break;
                default:
                    break;
            }
        }

        public static void Log(Exception ex)
        {
            Log(logger, ex);
        }

        public static void Log(Logger nLogger, Exception ex)
        {
            nLogger.Error(ex);
        }

        public static void Log(string msg)
        {
            Log(logger, msg);
        }

        public static void Log(Logger nLogger, string msg)
        {
            nLogger.Info(msg);
        }
    }
}
