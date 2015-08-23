namespace Logger.Layouts
{
    using System;
    using System.Text;

    using Logger.Contracts;

    public class XmlLayout : ILayout
    {
        public string Format(DateTime date, ReportLevel reportLevel, string message)
        {
            var formattedLog = new StringBuilder();

            formattedLog.AppendLine("<log>");
            formattedLog.AppendLine(string.Format("\t<date>{0}</date>", date));
            formattedLog.AppendLine(string.Format("\t<level>{0}</level>", reportLevel));
            formattedLog.AppendLine(string.Format("\t<message>{0}</message>", message));
            formattedLog.AppendLine("</log>");

            return formattedLog.ToString();
        }
    }
}