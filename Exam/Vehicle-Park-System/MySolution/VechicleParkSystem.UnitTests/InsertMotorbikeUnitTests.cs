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
    public class InsertMotorbikeUnitTests
    {
        private IVehiclePark park;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.park = new VehiclePark(2, 2);
        }

        [TestMethod]
        public void InsertMotorbike_CorrectParameters_ShouldInsertTheMotorbike()
        {
            var motorbike = new Motorbike("CA1011AH", "John Smith", 1);
            var message = this.park.InsertMotorbike(motorbike, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Motorbike parked successfully at place (1,1)", message);

            var motorbike2 = new Motorbike("CA1010AH", "Sarah Smith", 1);
            message = this.park.InsertMotorbike(motorbike2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Motorbike parked successfully at place (1,2)", message);
        }

        [TestMethod]
        public void InsertMotorbike_DuplicatePlace_ShouldNotInsertTheMotorbike()
        {
            var motorbike = new Motorbike("CA1011AH", "John Smith", 1);
            this.park.InsertMotorbike(motorbike, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var motorbike2 = new Motorbike("CA1010AH", "Sarah Smith", 1);
            var message = this.park.InsertMotorbike(motorbike2, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("The place (1,1) is occupied", message);
        }

        [TestMethod]
        public void InsertMotorbike_DuplicateMotorbike_ShouldNotInsertTheMotorbike()
        {
            var motorbike = new Motorbike("CA1011AH", "John Smith", 1);
            this.park.InsertMotorbike(motorbike, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var motorbike2 = new Motorbike("CA1011AH", "Sarah Smith", 1);
            var message = this.park.InsertMotorbike(motorbike2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is already a vehicle with license plate CA1011AH in the park", message);
        }

        [TestMethod]
        public void InsertMotorbike_WrongPlace_ShouldNotInsertTheMotorbike()
        {
            var motorbike = new Motorbike("CA1011AH", "John Smith", 1);
            var message = this.park.InsertMotorbike(motorbike, 1, 3, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no place 3 in sector 1", message);
        }

        [TestMethod]
        public void InsertMotorbike_WrongSector_ShouldNotInsertTheMotorbike()
        {
            var motorbike = new Motorbike("CA1011AH", "John Smith", 1);
            var message = this.park.InsertMotorbike(motorbike, 3, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no sector 3 in the park", message);
        }
    }
}