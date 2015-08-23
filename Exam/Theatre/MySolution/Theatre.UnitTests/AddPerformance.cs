// ReSharper disable InconsistentNaming
namespace Theatre.UnitTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Exeptions;
    using Theatre.Interfaces;

    [TestClass]
    public class AddPerformance
    {
        private Performance performance1;

        private Performance performance2;

        private Performance performance3;

        private IPerformanceDatabase performances;

        [TestInitialize]
        public void InitializeTest()
        {
            this.performances = new PerformanceDatabase();
            this.performances.AddTheatre("Theatre Sofia");
            this.performances.AddTheatre("Theatre 199");

            // Theatre 199, Duende, 20.01.2015 20:00, 1:30, 14.5
            this.performance1 = new Performance(
                "Theatre 199", 
                "Duende", 
                new DateTime(2015, 1, 19, 20, 0, 0), 
                new TimeSpan(0, 1, 30, 0), 
                14.5M);

            // Theatre 199, Bella Donna, 20.01.2015 20:30, 1:00, 12)
            this.performance2 = new Performance(
                "Theatre 199", 
                "Bella Donna", 
                new DateTime(2015, 1, 20, 20, 30, 0), 
                new TimeSpan(0, 1, 0, 0), 
                12.0M);

            // Theatre Sofia, Don Juan, 20.01.2015 20:31, 2:00, 14.60
            this.performance3 = new Performance(
                "Theatre Sofia", 
                "Don Juan", 
                new DateTime(2015, 1, 20, 20, 31, 0), 
                new TimeSpan(0, 2, 0, 0), 
                14.6M);
        }

        [TestMethod]
        public void AddPerformances_AddPerformanses()
        {
            this.performances.AddPerformance(
                "Theatre 199", 
                "Duende", 
                new DateTime(2015, 1, 19, 20, 0, 0), 
                new TimeSpan(0, 1, 30, 0), 
                14.5M);
            this.performances.AddPerformance(
                "Theatre 199", 
                "Bella Donna", 
                new DateTime(2015, 1, 20, 20, 30, 0), 
                new TimeSpan(0, 1, 0, 0), 
                12.0M);
            this.performances.AddPerformance(
                "Theatre Sofia", 
                "Don Juan", 
                new DateTime(2015, 1, 20, 20, 31, 0), 
                new TimeSpan(0, 2, 0, 0), 
                14.6M);

            Assert.AreEqual(3, this.performances.ListAllPerformances().Count());
            Assert.AreEqual(2, this.performances.ListPerformances("Theatre 199").Count());
            Assert.AreEqual(1, this.performances.ListPerformances("Theatre Sofia").Count());

            var expected = new[] { this.performance1, this.performance2, this.performance3 }.Select(p => p.ToString());
            var output = this.performances.ListAllPerformances().ToArray().Select(p => p.ToString());
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", output));

            expected = new[] { this.performance1, this.performance2 }.Select(p => p.ToString());
            output = this.performances.ListPerformances("Theatre 199").ToArray().Select(p => p.ToString());
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", output));

            expected = new[] { this.performance3 }.Select(p => p.ToString());
            output = this.performances.ListPerformances("Theatre Sofia").ToArray().Select(p => p.ToString());
            Assert.AreEqual(string.Join(", ", expected), string.Join(", ", output));
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void AddTheatre_Duplicates()
        {
            this.performances.AddPerformance(
                "Balgarska armia",
                "Duende",
                new DateTime(2015, 1, 19, 20, 0, 0),
                new TimeSpan(0, 1, 30, 0),
                14.5M);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void AddTheatre_TimeDurationOverlap()
        {
            this.performances.AddPerformance(
                "Theatre 199",
                "Bella Donna",
                new DateTime(2015, 1, 20, 20, 30, 0),
                new TimeSpan(0, 1, 0, 0),
                12.0M);
            this.performances.AddPerformance(
                "Theatre 199",
                "Frozen",
                new DateTime(2015, 1, 20, 20, 0, 0),
                new TimeSpan(0, 1, 30, 0),
                14.5M);
        }
    }
}