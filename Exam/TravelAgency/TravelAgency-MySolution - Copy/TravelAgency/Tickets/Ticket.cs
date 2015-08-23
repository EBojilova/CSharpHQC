namespace TravelAgency.Tickets
{
    using System;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(string from, string to, DateTime dateTime, decimal price)
        {
            // TODO: Validations if needed.
            this.From = from;
            this.To = to;
            this.DateAndTime = dateTime;
            this.Price = price;
        }

        public string From { get; private set; }

        public string To { get; private set; }

        public DateTime DateAndTime { get; private set; }

        public decimal Price { get; private set; }

        public abstract string TicketKey { get; }

        public abstract TicketType Type { get; }

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

        public static string CreateFromToKey(string from, string to)
        {
            return string.Format("{0}; {1}", from, to);
        }

        public override string ToString()
        {
            var input = string.Format(
                "[{0}; {1}; {2:f2}]", 
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"), 
                this.Type.ToString().ToLower(), 
                this.Price);

            return input;
        }
    }
}