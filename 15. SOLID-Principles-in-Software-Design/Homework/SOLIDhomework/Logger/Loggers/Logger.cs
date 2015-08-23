namespace Logger.Loggers
{
    using System;
    using System.Collections.Generic;

    using global::Logger.Contracts;

    public class Logger : ILogger
    {
        /// <summary>
        /// Bridge pattern- Logger depends on IAppender
        /// </summary>
        /// <param name="appenders"></param>
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public ICollection<IAppender> Appenders { get; private set; }

        public void Info(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void Warn(string message)
        {
            this.Log(message, ReportLevel.Warning);
        }

        public void Error(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void Critical(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void Fatal(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }

        private void Log(string message, ReportLevel reportLevel)
        {
            DateTime date = DateTime.Now;

            foreach (var appender in this.Appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
    }
}