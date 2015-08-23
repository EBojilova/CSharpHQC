namespace TravelAgency.Tickets
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentprice)
            : base(from, to, dateTime, price)
        {
            this.StudentPrice = studentprice;
        }

        public TrainTicket(string from, string to, DateTime dateTime)
            : base(from, to, dateTime, 0m)
        {
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
                return string.Format("{0};{1};{2};{3};", this.Type, this.From, this.To, this.DateAndTime);
            }
        }
    }
}