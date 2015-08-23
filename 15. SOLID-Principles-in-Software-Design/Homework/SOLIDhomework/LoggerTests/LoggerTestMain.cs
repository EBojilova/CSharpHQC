namespace LoggerTests
{
    using Logger;
    using Logger.Appenders;
    using Logger.Layouts;
    using Logger.Loggers;

    internal class LoggerTestMain
    {
        private static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();

            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "../../log.txt";

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");

            var xmlLayout = new XmlLayout();

            consoleAppender = new ConsoleAppender(xmlLayout);
            fileAppender = new FileAppender(xmlLayout);
            fileAppender.File = "../../log.txt";

            logger = new Logger(consoleAppender, fileAppender);
            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");

            consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;
            logger = new Logger(consoleAppender);
            logger.Info("Info: I should no be printed.");
            logger.Warn("Warning: I should no be printed.");
            logger.Error("Error parsing JSON.");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}