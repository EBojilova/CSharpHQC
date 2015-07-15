namespace _01.ReformatCode
{
    using System;

    internal class EventMain
    {
        private static void Main(string[] args)
        {
            while (CommandManager.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }
    }
}