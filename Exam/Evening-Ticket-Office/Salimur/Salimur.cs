using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Wintellect.PowerCollections;

// TODO: document this interface
// Do not modify the interface members
// Moving the interface to separate namespace is allowed
// Adding XML documentation is allowed
public interface ITicketRepository
{
    // TODO: document this method
    string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

    string DeleteAirTicket(string flightNumber);

    string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

    string DeleteTrainTicket(string from, string to, DateTime dateTime);

    string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

    // TODO: document this method
    string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

    // TODO: document this method
    string FindTickets(string from, string to);

    // TODO: document this method
    string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

    int GetTicketsCount(TicketType type);
}

internal class AircraftTicket : Ticket
{
    public AircraftTicket(string from, string to, string boatCompany, string dt, string pp)
    {
        this.From = from;

        this.To = to;
        this.Company = boatCompany;
        var dateAndTime = ParseDateTime(dt);
        this.DateAndTime = dateAndTime;
        var price = decimal.Parse(pp);
        this.Price = price;
    }

    public override string Type
    {
        get
        {
            return "aircraft";
        }
    }

    public override string property2
    {
        get
        {
            return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
        }
    }
}

public class class2 : ITicketRepository
{
    public int airTicketsCount;

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
            //var ticketsFound = this.Dict2[fromToKey];

            var ticketsFound = new List<Ticket>();
            foreach (var t in this.Dict2.Values)
            {
                if (t.FromToKey == fromToKey)
                {
                    ticketsFound.Add(t);
                }
            }

            //var ticketsFound2 = this.Dict2[fromToKey];
            //    List<Ticket> ticketsFound = new List<Ticket>();
            //    foreach (var t in this.Dict2.Values)
            //    {
            //        if (t.FromToKey == fromToKey){
            //            ticketsFound.Add(t);
            //    }
            //}

            var ticketsAsString = ReadTickets(ticketsFound);

            return ticketsAsString;
        }
        return "No matches";
    }

    public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
    {
        // Do not toch! It work!!! I spend 10 hours of fix buggy here
        var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;
        if (ticketsFound.Count > 20)
        {
            var ticketsAsString = ReadTickets(ticketsFound);

            return ticketsAsString;
        }
        return "No matches";
    }

    public string AddAirTicket(string nnn, string from, string to, string airline, DateTime dateTime, decimal price)
    {
        return this.AddAirTicket(nnn, from, to, airline, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
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
        return this.cbt(from, to, Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
    }

    public string DeleteBusTicket(string from, string to, string ccc, DateTime dateTime)
    {
        return this.DeleteBusTicket(from, to, ccc, dateTime.ToString("dd.MM.yyyy HH:mm"));
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

    string ITicketRepository.DeleteAirTicket(string nnn)
    {
        return this.DeleteAirTicket(nnn);
    }

    internal string AddDeleteTicket(Ticket ticket, bool isAdd)
    {
        if (isAdd)
        {
            var key = ticket.property2;
            if (this.Dict.ContainsKey(key))
            {
                return "Duplicated " + ticket.Type.ToLower();
            }
            this.Dict.Add(key, ticket);
            var fromToKey = ticket.FromToKey;

            this.Dict2.Add(fromToKey, ticket);
            this.Dict3.Add(ticket.DateAndTime, ticket);
            return ticket.Type + " added";
        }
        else
        {
            var key = ticket.property2;
            if (this.Dict.ContainsKey(key))
            {
                ticket = this.Dict[key];
                this.Dict.Remove(key);
                var fromToKey = ticket.FromToKey;

                this.Dict2.Remove(fromToKey, ticket);
                this.Dict3.Remove(ticket.DateAndTime, ticket);
                return ticket.Type + " deleted";
            }
            return ticket.Type + " does not exist";
        }
    }

    public string AddAirTicket(string nnn, string from, string to, string airline, string dt, string pp)
    {
        // Look video for brother of my wedding: https://www.youtube.com/watch?v=OXgcs_MeAHI
        var ticket = new AirTicket(nnn, from, to, airline, dt, pp);

        var result = this.AddDeleteTicket(ticket, true);
        if (result.Contains("created"))
        {
            this.airTicketsCount++;
        }
        return result;
    }

    protected string DeleteAirTicket(string nnn)
    {
        var ticket = new AirTicket(nnn);

        var result = this.AddDeleteTicket(ticket, false);
        if (result.Contains("deleted"))
        {
            this.airTicketsCount--;
        }
        return result;
    }

    public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
    {
        var ticket = new TrainTicket(from, to, dt, pp, studentpp);

        var result = this.AddDeleteTicket(ticket, true);
        if (result.Contains("created"))
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

    protected string cbt(string from, string to, string Sayahat_ki_Tanzeem, string dt, string pp)
    {
        var ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt, pp);
        var key = ticket.property2;
        string result;

        if (this.Dict.ContainsKey(key))
        {
            result = "Duplicated " + ticket.Type.ToLower();
        }
        else
        {
            this.Dict.Add(key, ticket);
            var fromToKey = ticket.FromToKey;

            this.Dict2.Add(fromToKey, ticket);
            this.Dict3.Add(ticket.DateAndTime, ticket);
            result = ticket.Type + " created";
        }

        if (result.Contains("created"))
        {
            this.busTicketsCount++;
        }
        return result;
    }

    private string DeleteBusTicket(string from, string to, string ccc, string dt)
    {
        var ticket = new BusTicket(from, to, ccc, dt);
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
                result += " ";
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
        //var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;

        var ticketsFound =
            this.Dict3.Values.Where(t => t.DateAndTime >= startDateTime)
                .Where(t => t.DateAndTime <= endDateTime)
                .ToList();

        if (ticketsFound.Count > 0)
        {
            var ticketsAsString = ReadTickets(ticketsFound);
            return ticketsAsString;
        }
        return "No matches";
    }

    internal string parseeeeeeee(string line)
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
            case "CreateFlight":
                var allParameters = line.Substring(firstSpaceIndex + 1);
                var parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
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
            case "DeleteFlight":

                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = parameters[i].Trim();
                }
                cd2 = this.DeleteAirTicket(parameters[0]);
                break;
            case "CreateTrain":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)

                {
                    parameters[i] = parameters[i].Trim();
                }
                cd2 = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                break;
            case "DeleteTrain":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = parameters[i].Trim();
                }
                cd2 = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                break;
            case "CreateBus":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = parameters[i].Trim();
                }
                cd2 = this.cbt(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                break;
            case "DeleteBus":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = parameters[i].Trim();
                }
                cd2 = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                break;
            case "FindTickets":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = parameters[i].Trim();
                }

                cd2 = this.FindTickets(parameters[0], parameters[1]);
                break;
            case "FindByDates":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
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

internal abstract class Ticket : IComparable<Ticket>
{
    public abstract string Type { get; }

    public virtual string From { get; set; }

    public virtual string To { get; set; }

    public virtual string Company { get; set; }

    public virtual DateTime DateAndTime { get; set; }

    public virtual decimal Price { get; set; }

    public virtual decimal SpecialPrice { get; set; }

    public abstract string property2 { get; }

    public string FromToKey
    {
        get
        {
            return CreateFromToKey(this.From, this.To);
        }
    }

    public int CompareTo(Ticket otherTicket)
    {
        var nateeja = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
        if (nateeja == 0)
        {
            nateeja = this.Type.CompareTo(otherTicket.Type);
        }
        if (nateeja == 0)
        {
            nateeja = this.Price.CompareTo(otherTicket.Price);
        }
        return nateeja;
    }

    public override string ToString()
    {
        var input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "|" + this.Type.ToUpper() + "|"
                    + string.Format("{0:f2}", this.Price) + "]";
        return input;
    }

    public static string CreateFromToKey(string from, string to)
    {
        return from + "; " + to;
    }

    public static DateTime ParseDateTime(string dt)
    {
        var result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        return result;
    }
}

internal class BusTicket : Ticket
{
    public BusTicket(string from, string to, string ccc, string dt, string pp)
    {
        this.From = from;
        this.To = to;
        this.Company = ccc;
        var dateAndTime = ParseDateTime(dt);

        this.DateAndTime = dateAndTime;
        var price = decimal.Parse(pp);
        this.Price = price;
    }

    public BusTicket(string from, string to, string ccc, string dt)
    {
        this.From = from;
        this.To = to;
        this.Company = ccc;

        var dateAndTime = ParseDateTime(dt);
        this.DateAndTime = dateAndTime;
    }

    public override string Type
    {
        get
        {
            return "Bus";
        }
    }

    public override string property2
    {
        get
        {
            return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
        }
    }
}

internal class AirTicket : Ticket
{
    public AirTicket(string nnn, string from, string to, string airline, string dt, string pp)
    {
        this.nnn = nnn;
        this.From = from;
        this.To = to;

        this.Company = airline;
        var dateAndTime = ParseDateTime(dt);
        this.DateAndTime = dateAndTime;
        var price = decimal.Parse(pp);
        this.Price = price;
    }

    public AirTicket(string nnn)
    {
        this.nnn = nnn;
    }

    public string nnn { get; set; }

    public override string Type
    {
        get
        {
            return "Flight";
        }
    }

    public override string property2
    {
        get
        {
            return this.Type + ";;" + this.nnn;
        }
    }
}

internal class Salimur
{
    private static void Main()
    {
        var c2 = new class2();
        while (true)
        {
            var line = Console.ReadLine();
            if (line == null)
            {
                break;
            }

            line = line.Trim();
            var commandResult = c2.parseeeeeeee(line);
            if (commandResult != null)
            {
                Console.WriteLine(commandResult);
            }
        }
    }
}

public enum TicketType
{
    Bus,

    Flight,

    Train
}

internal class TrainTicket : Ticket
{
    public TrainTicket(string from, string to, string dt, string pp, string studentpp)
    {
        this.From = from;
        this.To = to;
        var dateAndTime = ParseDateTime(dt);

        this.DateAndTime = dateAndTime;
        var price = decimal.Parse(pp);

        this.Price = price;
        var studentPrice = decimal.Parse(studentpp);

        this.StudentPrice = studentPrice;
    }

    public TrainTicket(string from, string to, string dt)
    {
        this.From = from;
        this.To = to;
        var dateAndTime = ParseDateTime(dt);

        this.DateAndTime = dateAndTime;
    }

    public decimal StudentPrice { get; set; }

    public override string Type
    {
        get
        {
            return "Train";
        }
    }

    public override string property2
    {
        get
        {
            return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
        }
    }
}