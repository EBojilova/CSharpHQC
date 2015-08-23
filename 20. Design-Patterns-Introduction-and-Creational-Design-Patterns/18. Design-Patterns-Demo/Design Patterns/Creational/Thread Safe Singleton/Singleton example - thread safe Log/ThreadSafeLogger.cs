namespace ThreadSafeSingleton.Logger
{
    using System;
    using System.Collections.Generic;

    public sealed class ThreadSafeLogger
    {
        private static volatile ThreadSafeLogger logger;

        ///izpolzva se samo za da se lockne
        private static readonly object SyncLock = new object();

        private readonly List<LogEvent> Events;

        private ThreadSafeLogger()
        {
            this.Events = new List<LogEvent>();
        }

        public static ThreadSafeLogger Instance
        {
            get
            {
                ///pravi se double null check za da ne se zadadat niakolko instancii na logera
                if (logger != null)
                {
                    return logger;
                }

                lock (SyncLock)
                {
                    if (logger == null)
                    {
                        logger = new ThreadSafeLogger();
                    }
                }

                return logger;
            }
        }

        public void SaveToLog(object message)
        {
            this.Events.Add(new LogEvent(message.ToString()));
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