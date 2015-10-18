namespace IssueTracker.Core
{
    using System;

    using global::IssueTracker.Interfaces;

    internal class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}