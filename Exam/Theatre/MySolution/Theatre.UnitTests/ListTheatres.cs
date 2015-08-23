// ReSharper disable InconsistentNaming
namespace Theatre.UnitTests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Exeptions;
    using Theatre.Interfaces;

    [TestClass]
    public class ListTheatre
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

            CollectionAssert.AreEqual(new[] { "Theatre Sofia" }, this.performances.ListTheatres().ToArray());

            this.performances.AddTheatre("Theatre 199");

            CollectionAssert.AreEqual(
                new[] { "Theatre 199", "Theatre Sofia" }, 
                this.performances.ListTheatres().ToArray());
        }

        [TestMethod]
        public void ListTheatre_Duplicates()
        {
            this.performances.AddTheatre("Theatre Sofia");
            try
            {
                this.performances.AddTheatre("Theatre Sofia");
            }
            catch (DuplicateTheatreException)
            {
            }

            CollectionAssert.AreEqual(new[] { "Theatre Sofia" }, this.performances.ListTheatres().ToArray());
        }
    }
}