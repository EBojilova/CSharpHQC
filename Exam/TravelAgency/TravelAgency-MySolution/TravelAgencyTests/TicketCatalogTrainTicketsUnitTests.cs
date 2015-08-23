namespace TravelAgencyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency;
    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    [TestClass]
    public class TicketCatalogTrainTicketsUnitTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void InitializeTest()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestAddTrainTicketReturnsTickedAdded()
        {
            var cmdResult = this.catalog.AddTrainTicket(
                "Sofia", 
                "Varna", 
                new DateTime(2015, 1, 30, 12, 55, 00), 
                20M, 
                13.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestAddTrainTicketDuplicates()
        {
            this.catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 20M, 13.50M);

            var cmdResult = this.catalog.AddTrainTicket(
                "Sofia", 
                "Varna", 
                new DateTime(2015, 1, 30, 12, 55, 00), 
                20M, 
                13.50M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDeleted()
        {
            this.catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 20M, 13.50M);

            var cmdResult = this.catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 20M, 13.50M);

            var cmdResult = this.catalog.DeleteTrainTicket("Gabrovo", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteDeletedTrainTicketReturnsTickedDoesNotExist()
        {
            this.catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 20M, 13.50M);
            this.catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            var cmdResult = this.catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
        }
    }
}