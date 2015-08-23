namespace TravelAgencyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TravelAgency;
    using TravelAgency.Interfaces;
    using TravelAgency.Tickets;

    [TestClass]
    public class TicketCatalogFindTicketsInIntervalUnitTests
    {
        [TestMethod]
        public void TestFindTicketsInIntervalReturnsTickets()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 26.00M, 16.30M);
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            catalog.AddAirTicket(from: "Sofia", to: "Plovdiv", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddBusTicket("Varna", "Pleven", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddTrainTicket("Sofia", "Veliko Tarnovo", new DateTime(2015, 1, 23, 12, 55, 00), 26.00M, 16.30M);
            catalog.AddBusTicket("Varna", "Sofia", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            var cmdResult = catalog.FindTicketsInInterval(new DateTime(2015, 1, 29, 7, 40, 00), new DateTime(2015, 1, 30, 12, 55, 00));

            var expectedCmdResult = "[29.01.2015 07:40; air; 24.00] [30.01.2015 11:35; bus; 25.00] [30.01.2015 12:55; train; 26.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsInIntervalReturnsNotFound()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 26.00M, 16.30M);
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            catalog.AddAirTicket(from: "Sofia", to: "Plovdiv", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddBusTicket("Varna", "Pleven", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddTrainTicket("Sofia", "Veliko Tarnovo", new DateTime(2015, 1, 23, 12, 55, 00), 26.00M, 16.30M);
            catalog.AddBusTicket("Varna", "Sofia", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            var cmdResult = catalog.FindTicketsInInterval(new DateTime(2015, 1, 29, 7, 40, 01), new DateTime(2015, 1, 30, 11, 34, 59));

            Assert.AreEqual("Not found", cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsCheckCorrectSortingOrder()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453-2");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 40, 00), price: 224.00M, airline: "Air BG", flightNumber: "S9473");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1224.00M, airline: "Air Travel Corp.", flightNumber: "V245X");

            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 29, 7, 40, 00), 26.00M, 16.30M);
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 26, 7, 40, 00), 24.00M, 16.30M);
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 28, 7, 45, 00), 26.00M, 16.30M);
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 24, 7, 40, 00), 426.55M, 16.30M);

            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet2");
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 28.00M, travelCompany: "Etap");
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 27, 7, 40, 00), price: 25.00M, travelCompany: "New Bus Corp.");
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 5.72M, travelCompany: "Sofia Bus Ltd.");
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1235.72M, travelCompany: "Varna Bus Travel Ltd.");

            var cmdResult = catalog.FindTicketsInInterval(new DateTime(1980, 1, 1, 0, 0, 0), new DateTime(2050, 2, 1, 0, 0, 0));

            var expectedCmdResult = "[24.01.2015 07:40; train; 426.55] " + "[26.01.2015 07:40; train; 24.00] " + "[27.01.2015 07:40; bus; 25.00] " + "[28.01.2015 07:40; air; 224.00] " + "[28.01.2015 07:45; train; 26.00] "
                                    + "[29.01.2015 07:40; air; 211.00] " + "[29.01.2015 07:40; air; 224.00] " + "[29.01.2015 07:40; air; 224.00] " + "[29.01.2015 07:40; air; 1224.00] " + "[29.01.2015 07:40; bus; 5.72] "
                                    + "[29.01.2015 07:40; bus; 25.00] " + "[29.01.2015 07:40; bus; 25.00] " + "[29.01.2015 07:40; bus; 28.00] " + "[29.01.2015 07:40; bus; 1235.72] " + "[29.01.2015 07:40; train; 26.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsCheckDeletedTickets()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 28, 7, 45, 00), 26.00M, 16.30M);
            catalog.AddBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            var cmdResult = catalog.FindTicketsInInterval(new DateTime(1980, 1, 1, 0, 0, 0), new DateTime(2050, 2, 1, 0, 0, 0));
            var expectedCmdResult = "[28.01.2015 07:45; train; 26.00] " + "[29.01.2015 07:40; air; 211.00] " + "[29.01.2015 07:40; bus; 25.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);

            catalog.DeleteAirTicket("SV1234");
            catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 28, 7, 45, 00));
            catalog.DeleteBusTicket("Sofia", "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), travelCompany: "Biomet");
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
            var cmdResultFind = catalog.FindTicketsInInterval(new DateTime(1980, 1, 1, 0, 0, 0), new DateTime(2050, 2, 1, 0, 0, 0));
            Assert.AreEqual("Not found", cmdResultFind);
        }
    }
}