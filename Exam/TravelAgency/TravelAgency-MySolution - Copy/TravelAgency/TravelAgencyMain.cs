namespace TravelAgency
{
    using System;

    internal class TravelAgencyMain
    {
        private static void Main()
        {
            var ticketCatalog = new TicketCatalog();
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
                var commandResult = ticketCatalog.ParseCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}