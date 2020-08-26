using System;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace Allo.Base.Helpers
{
    public static class Logger
    {
        //NOTE: ThreadStatic guaranty that logger is isolated for thread(parallel execution), but as it static it shared on whole project  
        [ThreadStatic]
        public static ILog Log;
        
        public static void Debug(object log)
        {
            Log.Debug(log);
        }

        public static void Info(object log)
        {
            Log.Info(log);
        }

        public static void Error(object log)
        {
            Log.Error(log);
        }

        #region MainMethods

        public static IAppender CreateFileAppender(string name,
            string fileName)
        {
            var layout = new PatternLayout
            {
                //NOTE: Pattern to print logs in console is taken from settings file
                ConversionPattern = ConfigurationHelper.GetConfiguration()["Logger:LogPattern"]
            };
            layout.ActivateOptions();

            var appender = new FileAppender
            {
                Name = name, 
                File = fileName, 
                AppendToFile = true,
                Layout = layout
            };
            appender.ActivateOptions();

            return appender;
        }

        public static IAppender CreateConsoleAppender(string name)
        {
            var layout = new PatternLayout
            {
                //NOTE: Pattern to print logs in console is taken from settings file
                ConversionPattern = ConfigurationHelper.GetConfiguration()["Logger:LogPattern"]
            };
            layout.ActivateOptions();

            var appender = new ConsoleAppender
            {
                Name = name,
                Layout = layout
            };
            appender.ActivateOptions();

            return appender;
        }

        // Set the level for a named logger
        public static void SetLevel(string loggerName, string levelName)
        {
            Log = LogManager.GetLogger(loggerName, levelName);
            var l = (log4net.Repository.Hierarchy.Logger)Log.Logger;

            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        // Add an appender to a logger
        public static void AddAppender(string loggerName,
            IAppender appender)
        {
            Log = LogManager.GetLogger(loggerName, loggerName);
            var l = (log4net.Repository.Hierarchy.Logger)Log.Logger;

            l.AddAppender(appender);
        }

        // Initialize Repository for logger
        internal static void InitializeRepository(string name)
        {
            ILoggerRepository repository = LogManager.CreateRepository(name);
            var hierarchy = (Hierarchy)repository;
            hierarchy.Threshold = Level.All;
            hierarchy.Configured = true;
        }

        /// <summary>
        /// This Method is used to Create new logger file
        /// </summary>
        /// <param name="name"></param>
        public static void Init(string name)
        {
            InitializeRepository($"Log4net.{name}");

            SetLevel($"Log4net.{name}", ConfigurationHelper.GetConfiguration()["Logger:LogLevel"]);
            AddAppender($"Log4net.{name}", CreateFileAppender(name, $"Logs/{name}/{name}_{DateTime.Now.Ticks}"));
            AddAppender($"Log4net.{name}", CreateConsoleAppender(name));
        }
        #endregion
    }
}
