namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly OrderedMultiDictionary<DateTime, Ticket> dictionaryDateAndTimeKey =
            new OrderedMultiDictionary<DateTime, Ticket>(true);

        private readonly MultiDictionary<string, Ticket> dictionaryFromToKey = new MultiDictionary<string, Ticket>(true);

        private readonly Dictionary<string, Ticket> dictionaryTicketKey = new Dictionary<string, Ticket>();

        private readonly Dictionary<TicketType, int> ticketCountByType = new Dictionary<TicketType, int>();

        public TicketCatalog()
        {
            this.ticketCountByType[TicketType.Air] = 0;
            this.ticketCountByType[TicketType.Bus] = 0;
            this.ticketCountByType[TicketType.Train] = 0;
        }

        public string FindTickets(string from, string to)
        {
            var fromToKey = Ticket.CreateFromToKey(from, to);
            if (!this.dictionaryFromToKey.ContainsKey(fromToKey))
            {
                return "Not found";
            }

            var ticketsAsString = FormatTicketsForPrinting(this.dictionaryFromToKey[fromToKey]);
            return ticketsAsString;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.dictionaryDateAndTimeKey.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = FormatTicketsForPrinting(ticketsFound);
                return ticketsAsString;
            }

            return "Not found";
        }

        public string AddAirTicket(
            string flightNumber, 
            string from, 
            string to, 
            string airline, 
            DateTime dateTime, 
            decimal price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);
            var result = this.DeleteTicket(ticket);

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentprice)
        {
            var ticket = new TrainTicket(from, to, dateTime, price, studentprice);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            var ticket = new TrainTicket(from, to, dateTime);
            var result = this.DeleteTicket(ticket);

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime, price);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime);
            var result = this.DeleteTicket(ticket);

            return result;
        }

        public int GetTicketsCount(TicketType type)
        {
            switch (type)
            {
                case TicketType.Air:
                    return this.ticketCountByType[TicketType.Air];
                case TicketType.Bus:
                    return this.ticketCountByType[TicketType.Bus];
            }

            return this.ticketCountByType[TicketType.Train];
        }

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
                    commandResult = this.AddAirTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        ParseDateTime(parameters[4]), 
                        decimal.Parse(parameters[5]));
                    break;
                case "DeleteAir":
                    commandResult = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    commandResult = this.AddTrainTicket(
                        parameters[0], 
                        parameters[1], 
                        ParseDateTime(parameters[2]), 
                        decimal.Parse(parameters[3]), 
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteTrain":
                    commandResult = this.DeleteTrainTicket(parameters[0], parameters[1], ParseDateTime(parameters[2]));
                    break;
                case "AddBus":
                    commandResult = this.AddBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]), 
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteBus":
                    commandResult = this.DeleteBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]));
                    break;
                case "FindTickets":
                    commandResult = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    var startDate = ParseDateTime(parameters[0]);
                    var endDate = ParseDateTime(parameters[1]);
                    commandResult = this.FindTicketsInInterval(startDate, endDate);
                    break;
            }

            return commandResult;
        }

        private static string FormatTicketsForPrinting(ICollection<Ticket> tickets)
        {
            var sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            var result = string.Join(" ", sortedTickets.Select(t => t.ToString()));

            return result;
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

        private string AddTicket(Ticket ticket)
        {
            var key = ticket.TicketKey;
            if (this.dictionaryTicketKey.ContainsKey(key))
            {
                return "Duplicate ticket";
            }

            this.dictionaryTicketKey.Add(key, ticket);
            var fromToKey = ticket.FromToKey;
            this.dictionaryFromToKey.Add(fromToKey, ticket);
            this.dictionaryDateAndTimeKey.Add(ticket.DateAndTime, ticket);
            this.ticketCountByType[ticket.Type]++;
            return "Ticket added";
        }

        private string DeleteTicket(Ticket ticket)
        {
            var key = ticket.TicketKey;
            if (!this.dictionaryTicketKey.ContainsKey(key))
            {
                return "Ticket does not exist";
            }

            ticket = this.dictionaryTicketKey[key];
            this.dictionaryTicketKey.Remove(key);
            var fromToKey = ticket.FromToKey;
            this.dictionaryFromToKey.Remove(fromToKey, ticket);
            this.dictionaryDateAndTimeKey.Remove(ticket.DateAndTime, ticket);
            this.ticketCountByType[ticket.Type]--;
            return "Ticket deleted";
        }
    }
}