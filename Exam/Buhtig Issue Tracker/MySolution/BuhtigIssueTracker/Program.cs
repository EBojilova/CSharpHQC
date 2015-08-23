namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;

    using BuhtigIssueTracker.Execution;

    internal class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var e = new Engine();

            e.Run();
        }
    }
}