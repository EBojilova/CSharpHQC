// ReSharper disable All
namespace TicketOffice
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using TicketOffice.Interfaces;
    using TicketOffice.Tickets;

    using Wintellect.PowerCollections;

    public class TicketRepository : ITicketRepository
    {
        private readonly MultiDictionary<string, Ticket> FromTo_Tickets = new MultiDictionary<string, Ticket>(true);

        private int airTicketsCount;

        private int busTicketsCount;

        private OrderedMultiDictionary<DateTime, Ticket> DateTime_Tickets =
            new OrderedMultiDictionary<DateTime, Ticket>(true);

        private Dictionary<string, Ticket> TicketKey_Ticket = new Dictionary<string, Ticket>();

        private int trainTicketsCount;

        public string FindTickets(string from, string to)
        {
            var fromToKey = Ticket.CreateFromToKey(from, to);

            if (this.FromTo_Tickets.ContainsKey(fromToKey))
            {
                var ticketsAsString = ReadTickets(this.FromTo_Tickets[fromToKey]);

                return ticketsAsString;
            }

            return "No matches";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.DateTime_Tickets.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Any())
            {
                var ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }

            return "No matches";
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Flight)
            {
                return this.airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        public string AddAirTicket(
            string flightNumber, 
            string from, 
            string to, 
            string airline, 
            DateTime dt, 
            decimal price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airline, dt, price);

            var result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);

            var result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dt, decimal price, decimal studentPrice)
        {
            var ticket = new TrainTicket(from, to, dt, price, studentPrice);

            var result = this.AddTicket(ticket);
            if (result.Contains("created"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dt)
        {
            var ticket = new TrainTicket(from, to, dt);
            var result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string company, DateTime dt, decimal price)
        {
            var ticket = new BusTicket(from, to, company, dt, price);
            var key = ticket.TicketKey;
            string result;

            if (this.TicketKey_Ticket.ContainsKey(key))
            {
                result = "Duplicated " + ticket.Type;
            }
            else
            {
                this.TicketKey_Ticket.Add(key, ticket);
                var fromToKey = ticket.FromToKey;

                this.FromTo_Tickets.Add(fromToKey, ticket);
                this.DateTime_Tickets.Add(ticket.DateAndTime, ticket);
                result = ticket.Type + " created";
            }

            if (result.Contains("created"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string from, string to, string company, DateTime dt)
        {
            var ticket = new BusTicket(from, to, company, dt);
            var result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        private string DeleteTicket(Ticket ticket)
        {
            var key = ticket.TicketKey;
            if (this.TicketKey_Ticket.ContainsKey(key))
            {
                ticket = this.TicketKey_Ticket[key];
                this.TicketKey_Ticket.Remove(key);
                var fromToKey = ticket.FromToKey;

                this.FromTo_Tickets.Remove(fromToKey, ticket);
                this.DateTime_Tickets.Remove(ticket.DateAndTime, ticket);
                return ticket.Type + " deleted";
            }

            return ticket.Type + " does not exist";
        }

        private string AddTicket(Ticket ticket)
        {
            var key = ticket.TicketKey;
            if (this.TicketKey_Ticket.ContainsKey(key))
            {
                return "Duplicated " + ticket.Type;
            }

            this.TicketKey_Ticket.Add(key, ticket);
            var fromToKey = ticket.FromToKey;

            this.FromTo_Tickets.Add(fromToKey, ticket);
            this.DateTime_Tickets.Add(ticket.DateAndTime, ticket);
            return ticket.Type + " added";
        }

        private static string ReadTickets(ICollection<Ticket> tickets)
        {
            var result = string.Join(" ", tickets.OrderBy(t => t));

            return result;
        }

        public string CommandParse(string input)
        {
            var firstSpaceIndex = input.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            var command = input.Substring(0, firstSpaceIndex);
            var parameters = SplitCommandParameters(input, firstSpaceIndex);

            switch (command)
            {
                case "CreateFlight":
                    return this.AddAirTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        ParseDateTime(parameters[4]), 
                        decimal.Parse(parameters[5]));
                case "DeleteFlight":
                    return this.DeleteAirTicket(parameters[0]);
                case "CreateTrain":
                    return this.AddTrainTicket(
                        parameters[0], 
                        parameters[1], 
                        ParseDateTime(parameters[2]), 
                        decimal.Parse(parameters[3]), 
                        decimal.Parse(parameters[4]));
                case "DeleteTrain":
                    return this.DeleteTrainTicket(parameters[0], parameters[1], ParseDateTime(parameters[2]));
                case "CreateBus":
                    return this.AddBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]), 
                        decimal.Parse(parameters[4]));
                case "DeleteBus":
                    return this.DeleteBusTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        ParseDateTime(parameters[3]));
                case "FindTickets":
                    return this.FindTickets(parameters[0], parameters[1]);
                case "FindByDates":
                    return this.FindTicketsInInterval(ParseDateTime(parameters[0]), ParseDateTime(parameters[1]));
                default:
                    return "Invalid command!";
            }
        }

        private static string[] SplitCommandParameters(string input, int firstSpaceIndex)
        {
            var commandParameters = input.Substring(firstSpaceIndex + 1);
            var parameters = commandParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            return parameters;
        }

        private static DateTime ParseDateTime(string dt)
        {
            var result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}