using System;
using System.IO;
using System.Threading;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace IFlow.Testing.Utils.Reports
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> LazyInstance = new Lazy<Logger>(() => new Logger());
        private static readonly ThreadLocal<ILogger> Log = new ThreadLocal<ILogger>(() => LogManager.GetLogger(Thread.CurrentThread.ManagedThreadId.ToString()));

        private Logger()
        {
            try
            {
                LogManager.LoadConfiguration("NLog.config");
            }
            catch (FileNotFoundException)
            {
                LogManager.Configuration = GetConfiguration();
            }
        }

        private LoggingConfiguration GetConfiguration()
        {
            var layout = "${threadid} ${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${level:uppercase=true} - ${message}";
            var config = new LoggingConfiguration();
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new ConsoleTarget("logconsole")
            {
                Layout = layout
            });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new CustomLogTarget()
            {
                Layout = layout
            });
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new FileTarget("logfile")
            {
                FileName = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Log/log.log")),
                Layout = layout,
                DeleteOldFileOnStartup = true
            });
            return config;
        }

        /// <summary>
        /// Gets Logger instance.
        /// </summary>
        public static Logger Instance => LazyInstance.Value;

        /// <summary>
        /// Log debug message and optional exception.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        public void Debug(string message, Exception exception = null)
        {
            Log.Value.Debug(exception, message);
        }

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">Message</param>
        public void Info(string message)
        {
            Log.Value.Info(message);
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">Message</param>
        public void Warn(string message)
        {
            Log.Value.Warn(message);
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">Message</param>
        public void Error(string message)
        {
            Log.Value.Error(message);
        }

        /// <summary>
        /// Log fatal message and exception.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        public void Fatal(string message, Exception exception)
        {
            Log.Value.Fatal(exception, message);
        }
    }
}
