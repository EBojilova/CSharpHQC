namespace Logger.Layouts
{
    using System;

    using Logger.Contracts;

    public class SimpleLayout : ILayout
    {
        private const string LayoutFormat = "{0} - {1} - {2}{3}";
        
        public string Format(DateTime date, ReportLevel reportLevel, string message)
        {
            var formattedMessage = string.Format(LayoutFormat, date, reportLevel, message, Environment.NewLine);

            return formattedMessage;
        }
    }
}