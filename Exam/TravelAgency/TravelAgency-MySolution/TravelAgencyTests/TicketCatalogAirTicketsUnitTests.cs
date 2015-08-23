namespace TravelAgencyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency;
    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    [TestClass]
    public class TicketCatalogAirTicketsUnitTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestAddAirTicketReturnsTickedAdded()
        {
            var cmdResult = this.catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketReturnsTickedAddedPex()
        {
            var cmdResult = this.catalog.AddAirTicket(null, null, null, null, default(DateTime), default(decimal));
            Assert.AreEqual("Ticket added", cmdResult);
            Assert.IsNotNull(this.catalog);
        }

        [TestMethod]
        public void TestAddAirTicketDuplicates()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            var cmdResult = this.catalog.AddAirTicket("FX215", "Sofia", "London", "Wizz Air", new DateTime(2015, 1, 22, 06, 15, 00), 730.55M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDeleted()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            var cmdResult = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            var cmdResult = this.catalog.DeleteAirTicket("FX217");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteDeletedAirTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);
            this.catalog.DeleteAirTicket("FX215");

            var cmdResult = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }
    }
}