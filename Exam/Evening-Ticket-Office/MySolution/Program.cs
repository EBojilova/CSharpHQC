namespace TicketOffice
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var repository = new TicketRepository();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                input = input.Trim();
                var commandResult = repository.CommandParse(input);

                Console.WriteLine(commandResult);
            }
        }
    }
}