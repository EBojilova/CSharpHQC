namespace TicketOffice.Tickets
{
    using System;

    internal class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airline, DateTime dt, decimal price)
            : base(from, to, dt, price)
        {
            this.FlightNumber = flightNumber;
            this.Company = airline;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber { get; set; }

        public string Company { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Flight;
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.Type + ";" + this.FlightNumber;
            }
        }
    }
}