namespace BuhtigIssueTracker
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using BuhtigIssueTracker.Execution;

    internal class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var e = new Engine();

            using (var writher = new StreamWriter(@"../../OUTPUT.txt", false))
            {
                Console.SetOut(writher);

            e.Run();
        }
    }
    }
}