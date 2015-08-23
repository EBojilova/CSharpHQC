namespace TicketOffice.Tickets
{
    using System;

    internal abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(string from, string to, DateTime dt, decimal price)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = dt;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime DateAndTime { get; set; }

        public decimal Price { get; set; }

        public abstract string TicketKey { get; }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(this.From, this.To);
            }
        }

        public int CompareTo(Ticket otherTicket)
        {
            var result = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (result == 0)
            {
                result = this.Type.CompareTo(otherTicket.Type);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(otherTicket.Price);
            }

            return result;
        }

        public override string ToString()
        {
            var input = string.Format(
                "[{0}|{1}|{2:f2}]",
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"),
                this.Type,
                this.Price);
            return input;
        }

        public static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }
    }
}