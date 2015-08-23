namespace Nashmat
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class fehrist_Parwana : ITicketCatalog
    {
        public int AirTicketsCount;

        public int busTicketsCount;

        internal Dictionary<string, Ticket> Dict = new Dictionary<string, Ticket>();

        private readonly MultiDictionary<string, Ticket> Dict2 = new MultiDictionary<string, Ticket>(true);

        internal OrderedMultiDictionary<DateTime, Ticket> Dict3 = new OrderedMultiDictionary<DateTime, Ticket>(true);

        public int trainTicketsCount;

        public string FindTickets(string from, string to)
        {
            var fromToKey = Ticket.CreateFromToKey(from, to);
            if (this.Dict2.ContainsKey(fromToKey))
            {
                var ticketsFound = new List<Ticket>();
                foreach (var t in this.Dict2.Values)
                {
                    if (t.FromToKey == fromToKey)
                    {
                        ticketsFound.Add(t);
                    }
                }

                var ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            return "Not found";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            // Do not toch! It work!!! I spend 10 hours of fix buggy here
            var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            return "Not found";
        }

        public string AddAirTicket(
            string parwaaz_number,
            string from,
            string to,
            string airline,
            DateTime dateTime,
            decimal price)
        {
            return this.AddAirTicket(
                parwaaz_number,
                from,
                to,
                airline,
                dateTime.ToString("dd.MM.yyyy HH:mm"),
                price.ToString());
        }

        string ITicketCatalog.DeleteAirTicket(string parwaaz_number)
        {
            return this.DeleteAirTicket(parwaaz_number);
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            return this.AddTrainTicket(
                from,
                to,
                dateTime.ToString("dd.MM.yyyy HH:mm"),
                price.ToString(),
                studentPrice.ToString());
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            return this.DeleteTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime, decimal price)
        {
            return this.basKaTicketKaIzafah(
                from,
                to,
                Sayahat_ki_Tanzeem,
                dateTime.ToString("dd.MM.yyyy HH:mm"),
                price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime)
        {
            return this.DeleteBusTicket(from, to, Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return this.AirTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }
            return this.trainTicketsCount;
        }

        public int GetTicketsCount(string type)
        {
            if (type == "air")
            {
                return this.AirTicketsCount;
            }

            if (type == "bus")
            {
                return this.busTicketsCount;
            }
            return this.trainTicketsCount;
        }

        internal string AddDeleteTicket(Ticket ticket, bool isAdd)
        {
            if (isAdd)
            {
                var key = ticket.MunfaridKuleed;
                if (this.Dict.ContainsKey(key))
                {
                    return "Duplicated ticket";
                }
                this.Dict.Add(key, ticket);
                var fromToKey = ticket.FromToKey;

                this.Dict2.Add(fromToKey, ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
            else
            {
                var key = ticket.MunfaridKuleed;
                if (this.Dict.ContainsKey(key))
                {
                    ticket = this.Dict[key];
                    this.Dict.Remove(key);
                    var fromToKey = ticket.FromToKey;

                    this.Dict2.Remove(fromToKey, ticket);
                    this.Dict3.Remove(ticket.DateAndTime, ticket);
                    return "Ticket deleted";
                }
                return "Ticket does not exist";
            }
        }

        public string AddAirTicket(string parwaaz_number, string from, string to, string airline, string dt, string pp)
        {
            // Look video for brother of my wedding: https://www.youtube.com/watch?v=OXgcs_MeAHI
            var ticket = new AirTicket(parwaaz_number, from, to, airline, dt, pp);

            var result = this.AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                this.AirTicketsCount++;
            }
            return result;
        }

        protected string DeleteAirTicket(string parwaaz_number)
        {
            var ticket = new AirTicket(parwaaz_number);

            var result = this.AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                this.AirTicketsCount--;
            }
            return result;
        }

        public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            var ticket = new TrainTicket(from, to, dt, pp, studentpp);

            var result = this.AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }
            return result;
        }

        private string DeleteTrainTicket(string from, string to, string dt)
        {
            var ticket = new TrainTicket(from, to, dt);
            var result = this.AddDeleteTicket(ticket, false);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }
            return result;
        }

        protected string basKaTicketKaIzafah(string from, string to, string Sayahat_ki_Tanzeem, string dt, string pp)
        {
            var ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt, pp);
            var key = ticket.MunfaridKuleed;
            string result;

            if (this.Dict.ContainsKey(key))
            {
                result = "Duplicate ticket";
            }
            else
            {
                this.Dict.Add(key, ticket);
                var fromToKey = ticket.FromToKey;

                this.Dict2.Add(fromToKey, ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
                result = "Ticket added";
            }

            if (result.Contains("added"))
            {
                this.busTicketsCount++;
            }
            return result;
        }

        private string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt)
        {
            var ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt);
            var result = this.AddDeleteTicket(ticket, false);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }
            return result;
        }

        internal static string ReadTickets(ICollection<Ticket> tickets)
        {
            var sortedTickets = new List<Ticket>(tickets);

            sortedTickets.Sort();
            var result = "";

            for (var i = 0; i < sortedTickets.Count; i++)
            {
                var ticket = sortedTickets[i];

                result += ticket.ToString();

                if (i < sortedTickets.Count - 1)
                {
                    result += ",  ";
                }
            }
            return result;
        }

        public string findTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            var startDateTime = Ticket.ParseDateTime(startDateTimeStr);

            var endDateTime = Ticket.ParseDateTime(endDateTimeStr);

            var ticketsAsString = this.FindTicketsInInterval(startDateTime, endDateTime);
            return ticketsAsString;
        }

        public string FindTicketsInInterval2(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;

            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }
            return "Not found";
        }

        internal string AmalKamaan(string line)
        {
            if (line == "")
            {
                return null;
            }

            var firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            var cd = line.Substring(0, firstSpaceIndex);
            var cd2 = "Invalid command!";
            switch (cd)
            {
                case "AddAir":
                    var allParameters = line.Substring(firstSpaceIndex + 1);
                    var parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.AddAirTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        parameters[4],
                        parameters[5]);
                    break;
                case "DeleteAir":

                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)

                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "AddBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.basKaTicketKaIzafah(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        parameters[4]);
                    break;
                case "DeleteBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = this.findTicketsInInterval(parameters[0], parameters[1]);
                    break;
            }
            return cd2;
        }
    }
}