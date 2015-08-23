// ReSharper disable InconsistentNaming
namespace VechicleParkSystem.UnitTests
{
    using System;
    using System.Globalization;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VechicleParkSystem.Interfaces;
    using VechicleParkSystem.VehicleParkObjects;
    using VechicleParkSystem.Vehicles;

    [TestClass]
    public class InsertTruckUnitTests
    {
        private IVehiclePark park;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.park = new VehiclePark(2, 2);
        }

        [TestMethod]
        public void InsertTruck_CorrectParameters_ShouldInsertTheTruck()
        {
            var truck = new Truck("CA1011AH", "John Smith", 1);
            var message = this.park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Truck parked successfully at place (1,1)", message);

            var truck2 = new Truck("CA1010AH", "Sarah Smith", 1);
            message = this.park.InsertTruck(truck2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Truck parked successfully at place (1,2)", message);
        }

        [TestMethod]
        public void InsertTruck_DuplicatePlace_ShouldNotInsertTheTruck()
        {
            var truck = new Truck("CA1011AH", "John Smith", 1);
            this.park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var truck2 = new Truck("CA1010AH", "Sarah Smith", 1);
            var message = this.park.InsertTruck(truck2, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("The place (1,1) is occupied", message);
        }

        [TestMethod]
        public void InsertTruck_DuplicateTruck_ShouldNotInsertTheTruck()
        {
            var truck = new Truck("CA1011AH", "John Smith", 1);
            this.park.InsertTruck(truck, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var truck2 = new Truck("CA1011AH", "Sarah Smith", 1);
            var message = this.park.InsertTruck(truck2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is already a vehicle with license plate CA1011AH in the park", message);
        }

        [TestMethod]
        public void InsertTruck_WrongPlace_ShouldNotInsertTheTruck()
        {
            var truck = new Truck("CA1011AH", "John Smith", 1);
            var message = this.park.InsertTruck(truck, 1, 3, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no place 3 in sector 1", message);
        }

        [TestMethod]
        public void InsertTruck_WrongSector_ShouldNotInsertTheTruck()
        {
            var truck = new Truck("CA1011AH", "John Smith", 1);
            var message = this.park.InsertTruck(truck, 3, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no sector 3 in the park", message);
        }
    }
}