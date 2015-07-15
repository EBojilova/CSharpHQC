namespace _01.ReformatCode
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly string location;

        private readonly string title;

        private DateTime date;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            var comparingDate = this.date.CompareTo(other.date);
            var comparingTitle = string.Compare(this.title, other.title, StringComparison.Ordinal);

            var comparingLocation = string.Compare(this.location, other.location, StringComparison.Ordinal);
            if (comparingDate == 0)
            {
                if (comparingTitle == 0)
                {
                    return comparingLocation;
                }

                return comparingTitle;
            }

            return comparingDate;
        }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}