namespace Logger.Appenders
{
    using System;

    using Logger.Contracts;

    public abstract class Appender : IAppender
    {
        /// <summary>
        /// Brige pattern- abstract Appender depends on ILayout
        /// </summary>
        /// <param name="layout"></param>
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ILayout Layout { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            var formattedMessage = this.Layout.Format(date, reportLevel, message);
            this.WriteFormatedMessage(formattedMessage);
        }

        public abstract void WriteFormatedMessage(string formattedMessage);
    }
}