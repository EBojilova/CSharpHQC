namespace TicketOffice.Tickets
{
    using System;

    internal class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string company, DateTime dt, decimal price = 0)
            : base(from, to, dt, price)
        {
            this.Company = company;
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
                return this.Type + ";" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}