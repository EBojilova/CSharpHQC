namespace TravelAgencyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency;
    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    [TestClass]
    public class TicketCatalogBusTicketsUnitTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestAddBusTicketReturnsTickedAdded()
        {
            var cmdResult = this.catalog.AddBusTicket(
                "Sofia", 
                "Varna", 
                "Balkan", 
                new DateTime(2015, 1, 30, 12, 55, 00), 
                13.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddBusTicketDuplicates()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Balkan", new DateTime(2015, 1, 30, 12, 55, 00), 13.50M);

            var cmdResult = this.catalog.AddBusTicket(
                "Sofia", 
                "Varna", 
                "Balkan", 
                new DateTime(2015, 1, 30, 12, 55, 00), 
                13.50M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDeleted()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Balkan", new DateTime(2015, 1, 30, 12, 55, 00), 13.50M);

            var cmdResult = this.catalog.DeleteBusTicket(
                "Sofia", 
                "Varna", 
                "Balkan", 
                new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Balkan", new DateTime(2015, 1, 30, 12, 55, 00), 13.50M);

            var cmdResult = this.catalog.DeleteBusTicket(
                "Gabrovo", 
                "Varna", 
                "Balkan", 
                new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteDeletedBusTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Balkan", new DateTime(2015, 1, 30, 12, 55, 00), 13.50M);
            this.catalog.DeleteBusTicket("Sofia", "Varna", "Balkan", new DateTime(2015, 1, 30, 12, 55, 00));

            var cmdResult = this.catalog.DeleteBusTicket(
                "Sofia", 
                "Varna", 
                "Balkan", 
                new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}