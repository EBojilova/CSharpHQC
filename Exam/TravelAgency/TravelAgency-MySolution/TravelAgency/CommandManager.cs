namespace TravelAgency
{
    using System;
    using System.Globalization;

    using TravelAgency.Interfaces;

    public class CommandManager
    {
        private static readonly ITicketCatalog TicketCatalog = new TicketCatalog();

        public string ParseCommand(string line)
        {
            if (line == string.Empty)
            {
                throw new InvalidOperationException("Command can not be null!");
            }

            var firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var commandName = line.Substring(0, firstSpaceIndex);
            var parameters = GetCommandParameters(line, firstSpaceIndex);
            var commandResult = "Invalid command!";
            switch (commandName)
            {
                case "AddAir":
                    commandResult = TicketCatalog.AddAirTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        ParseDateTime(parameters[4]), 
                        decimal.Parse(parameters[5]));
                    break;
                case "DeleteAir":
                    commandResult = TicketCatalog.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    commandResult = TicketCatalog.AddTrainTicket(
                        parameters[0], 
                        parameters[1], 
                        ParseDateTime(parameters[2]), 
                        decimal.Parse(parameters[3]), 
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteTrain":
                    commandResult = TicketCatalog.DeleteTrainTicket(
                        parameters[0], 
                        parameters[1], 
                        ParseDateTime(parameters[2]));
                    break;
                case "AddBus":
                    commandResult = TicketCatalog.AddBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]), 
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteBus":
                    commandResult = TicketCatalog.DeleteBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]));
                    break;
                case "FindTickets":
                    commandResult = TicketCatalog.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    var startDate = ParseDateTime(parameters[0]);
                    var endDate = ParseDateTime(parameters[1]);
                    commandResult = TicketCatalog.FindTicketsInInterval(startDate, endDate);
                    break;
            }

            return commandResult;
        }

        private static string[] GetCommandParameters(string line, int firstSpaceIndex)
        {
            var allParameters = line.Substring(firstSpaceIndex + 1);
            var parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            return parameters;
        }

        private static DateTime ParseDateTime(string dateTime)
        {
            var result = DateTime.ParseExact(dateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}