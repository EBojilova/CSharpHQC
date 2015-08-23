namespace TravelAgency
{
    using System;

    internal class TravelAgencyMain
    {
        private static readonly CommandManager CommandManager = new CommandManager();
        
        private static void Main()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (line == string.Empty)
                {
                    continue;
                }

                line = line.Trim();
                var commandResult = CommandManager.ParseCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}