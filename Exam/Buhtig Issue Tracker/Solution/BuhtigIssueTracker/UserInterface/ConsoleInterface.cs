namespace BuhtigIssueTracker.UserInterface
{
    using System;
    using BuhtigIssueTracker.Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
