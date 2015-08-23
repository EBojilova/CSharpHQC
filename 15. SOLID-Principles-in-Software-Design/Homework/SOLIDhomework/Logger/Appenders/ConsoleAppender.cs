namespace Logger.Appenders
{
    using System;

    using Logger.Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void WriteFormatedMessage(string formattedMessage)
        {
            Console.Write(formattedMessage);
        }
    }
}