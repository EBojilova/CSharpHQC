namespace Singleton.Logger
{
    using System;
    using System.Collections.Generic;

    // sealed- niama naslednici-samo edin e
    public sealed class Logger
    {
        // ako ne e static, triabva da:
        /// private readonly Logger logger;- vij i zakomentiranata proverka v Instance
        private static readonly Logger logger = new Logger();

        private readonly List<LogEvent> Events;

        private Logger()
        {
            this.Events = new List<LogEvent>();
        }

        public static Logger Instance
        {
            get
            {
                ////if (logger == null)
                ////{
                ////    logger = new Logger();
                ////}

                return logger;
            }
        }

        public void SaveToLog(string message)
        {
            this.Events.Add(new LogEvent(message));
        }

        public void PrintLog()
        {
            foreach (var ev in this.Events)
            {
                Console.WriteLine("Time: {0}, Event: {1}", ev.EventDate.ToShortTimeString(), ev.Message);
            }
        }
    }
}