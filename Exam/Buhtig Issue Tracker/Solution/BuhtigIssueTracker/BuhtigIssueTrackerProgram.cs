namespace BuhtigIssueTracker
{
    using System;
    using System.Globalization;
    using System.Threading;
    using BuhtigIssueTracker.Execution;

    public class BuhtigIssueTrackerProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new IssueTrackerEngine();
            engine.Run();
        }
    }
}
