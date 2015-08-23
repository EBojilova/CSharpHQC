namespace Theatre
{
    using System;
    using System.Collections.Generic;

    using Theatre.Exeptions;
    using Theatre.Interfaces;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theathrePerformances =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.theathrePerformances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theathrePerformances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var performances = this.theathrePerformances.Keys;
            return performances;
        }

        void IPerformanceDatabase.AddPerformance(
            string theatreName, 
            string performanceTitle, 
            DateTime startDateTime, 
            TimeSpan duration, 
            decimal price)
        {
            if (!this.theathrePerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesPerTheatre = this.theathrePerformances[theatreName];
            var endDateTime = startDateTime + duration;
            if (ArePerformancesOverlaped(performancesPerTheatre, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatreName, performanceTitle, startDateTime, duration, price);
            this.theathrePerformances[theatreName].Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theathrePerformances.Keys;

            var allPerformances = new List<Performance>();
            foreach (var theathre in theatres)
            {
                var performancesPerTheathre = this.theathrePerformances[theathre];
                allPerformances.AddRange(performancesPerTheathre);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theathrePerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesPerTheatre = this.theathrePerformances[theatreName];
            return performancesPerTheatre;
        }

        private static bool ArePerformancesOverlaped(
            IEnumerable<Performance> performances, 
            DateTime startTimeChecked, 
            DateTime endTimeChecked)
        {
            foreach (var performance in performances)
            {
                var startTime = performance.StartDateTime;
                var endTime = performance.StartDateTime + performance.Duration;
                var arePerformancesOverlaped = (startTime <= startTimeChecked && startTimeChecked <= endTime)
                                               || (startTime <= endTimeChecked && endTimeChecked <= endTime)
                                               || (startTimeChecked <= startTime && startTime <= endTimeChecked)
                                               || (startTimeChecked <= endTime && endTime <= endTimeChecked);
                if (arePerformancesOverlaped)
                {
                    return true;
                }
            }

            return false;
        }
    }
}