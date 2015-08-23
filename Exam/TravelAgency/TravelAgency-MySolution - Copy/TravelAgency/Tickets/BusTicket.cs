namespace TravelAgency.Tickets
{
    using System;

    internal class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
            : base(from, to, dateTime, price)
        {
            this.Company = travelCompany;
        }

        public BusTicket(string from, string to, string travelCompany, DateTime dateTime)
            : this(from, to, travelCompany, dateTime, 0m)
        {
        }

        public string Company { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Bus;
            }
        }

        public override string TicketKey
        {
            get
            {
                return string.Format(
                    "{0};{1};{2};{3};{4};", 
                    this.Type, 
                    this.From, 
                    this.To, 
                    this.Company, 
                    this.DateAndTime);
            }
        }
    }
}