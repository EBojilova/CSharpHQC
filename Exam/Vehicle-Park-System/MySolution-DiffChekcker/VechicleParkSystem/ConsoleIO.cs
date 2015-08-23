namespace VechicleParkSystem
{
    using System;

    using VechicleParkSystem.Interfaces;

    public class ConsoleIo : IUserInterface
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