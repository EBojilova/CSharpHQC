namespace Theatre
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theathreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheathreName = theathreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration;
            this.Price = price;
        }
        // TODO: Validations
        public string TheathreName { get; protected internal set; }

        public string PerformanceTitle { get; private set; }

        public DateTime StartDateTime { get; set; }

        public TimeSpan Duration { get; private set; }

        protected internal decimal Price { get; protected set; }

        public int CompareTo(Performance otherPerformance)
        {
            var result = this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
            return result;
        }

        public override string ToString()
        {
            var result = string.Format(
                "Performance(Theatre: {0}; Performance: {1}; StartDateTime: {2}, Duration: {3}, Price: {4})", 
                this.TheathreName, 
                this.PerformanceTitle, 
                this.StartDateTime.ToString("dd.MM.yyyy HH:mm"), 
                this.Duration.ToString("hh':'mm"), 
                this.Price.ToString("f2"));
            return result;
        }
    }
}