namespace Logger.Appenders
{
    using System;

    using Logger.Contracts;

    public class FileAppender : Appender
    {
        private string file;

        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                if (value != "../../log.txt")
                {
                    throw new ArgumentNullException("value", "File path should be ../../log.txt");
                }

                this.file = value;
            }
        }

        public override void WriteFormatedMessage(string formattedMessage)
        {
            System.IO.File.AppendAllText(this.File, formattedMessage);
        }
    }
}