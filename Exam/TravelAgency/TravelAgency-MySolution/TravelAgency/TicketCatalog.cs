namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
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

            //// BottleNeck found:
            ////var ticketsFound = this.dictionaryFromToKey.Values.Where(t => t.FromToKey == fromToKey).ToList();
            ////var ticketsAsString = FormatTicketsForPrinting(ticketsFound);
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

        private static string FormatTicketsForPrinting(ICollection<Ticket> tickets)
        {
            var sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            var result = string.Join(" ", sortedTickets.Select(t => t.ToString()));

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