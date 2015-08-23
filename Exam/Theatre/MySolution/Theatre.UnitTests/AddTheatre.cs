// ReSharper disable InconsistentNaming
namespace Theatre.UnitTests
{
    using System.Linq;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Exeptions;
    using Theatre.Interfaces;

    [TestClass]
    public class AddTheatre
    {
        private IPerformanceDatabase performances;

        [TestInitialize]
        public void InitializeTest()
        {
            this.performances = new PerformanceDatabase();
        }

        [TestMethod]
        public void AddTheatre_AddTheatres()
        {
            this.performances.AddTheatre("Theatre Sofia");

            Assert.AreEqual(1, this.performances.ListTheatres().Count());
            CollectionAssert.AreEqual(new[] { "Theatre Sofia" }, this.performances.ListTheatres().ToArray());

            this.performances.AddTheatre("Theatre 199");

            Assert.AreEqual(2, this.performances.ListTheatres().Count());
            CollectionAssert.AreEqual(new[] { "Theatre 199", "Theatre Sofia", }, this.performances.ListTheatres().ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void AddTheatre_Duplicates()
        {
            this.performances.AddTheatre("Theatre Sofia");
            this.performances.AddTheatre("Theatre Sofia");
        }
    }
}