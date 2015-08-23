namespace TravelAgencyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency;
    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    [TestClass]
    public class TicketCatalogGetTicketsCountUnitTests
    {
        [TestMethod]
        public void TestGetTicketsCountEmptyReturns0()
        {
            ITicketCatalog catalog = new TicketCatalog();
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetAirTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);
            catalog.AddAirTicket("FX407", "Varna", "Sofia", "Bulgaria Air", new DateTime(2015, 2, 2, 7, 45, 00), 135.00M);
            Assert.AreEqual(2, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestGetBusTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 50, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddBusTicket("Sofia", "Pleven", dateTime: new DateTime(2015, 1, 29, 8, 00, 00), price: 12.00M, travelCompany: "Pleven Trans");
            catalog.AddBusTicket("Varna", "Rousse", dateTime: new DateTime(2015, 1, 29, 7, 00, 00), price: 17.00M, travelCompany: "Etap");
            Assert.AreEqual(3, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestGetTrainTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 29, 7, 40, 00), 26.00M, 16.30M);
            catalog.AddTrainTicket("Sofia", "Pleven", new DateTime(2015, 1, 26, 8, 56, 00), 14.00M, 8.30M);
            Assert.AreEqual(2, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetTicketsCountForDeletedTicketsReturnsZero()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 28, 7, 45, 00), 26.00M, 16.30M);
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));

            catalog.DeleteAirTicket("SV1234");
            catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 28, 7, 45, 00));
            catalog.DeleteBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), travelCompany: "Biomet");
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}