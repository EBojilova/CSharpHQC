namespace TicketOffice.Tickets
{
    using System;

    internal class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dt, decimal price = 0, decimal studentPrice = 0)
            : base(from, to, dt, price)
        {
            this.StudentPrice = studentPrice;
        }

        public decimal StudentPrice { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Train;
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.Type + ";" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}