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
    public class InsertCarUnitTests
    {
        private IVehiclePark park;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.park = new VehiclePark(2, 2);
        }

        [TestMethod]
        public void InsertCar_CorrectParameters_ShouldInsertTheCar()
        {
            var car = new Car("CA1011AH", "John Smith", 1);
            var message = this.park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (1,1)", message);

            var car2 = new Car("CA1010AH", "Sarah Smith", 1);
            message = this.park.InsertCar(car2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (1,2)", message);

            var car3 = new Car("CA1012AH", "Linda Smith", 1);
            message = this.park.InsertCar(car3, 2, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (2,1)", message);

            var car4 = new Car("CA1013AH", "Linda Cloe", 1);
            message = this.park.InsertCar(car4, 2, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("Car parked successfully at place (2,2)", message);
        }

        [TestMethod]
        public void InsertCar_DuplicatePlace_ShouldNotInsertTheCar()
        {
            var car = new Car("CA1011AH", "John Smith", 1);
            this.park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var car2 = new Car("CA1010AH", "Sarah Smith", 1);
            var message = this.park.InsertCar(car2, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("The place (1,1) is occupied", message);
        }

        [TestMethod]
        public void InsertCar_DuplicateCar_ShouldNotInsertTheCar()
        {
            var car = new Car("CA1011AH", "John Smith", 1);
            this.park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var car2 = new Car("CA1011AH", "Sarah Smith", 1);
            var message = this.park.InsertCar(car2, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is already a vehicle with license plate CA1011AH in the park", message);
        }

        [TestMethod]
        public void InsertCar_WrongPlace_ShouldNotInsertTheCar()
        {
            var car = new Car("CA1011AH", "John Smith", 1);
            var message = this.park.InsertCar(car, 1, 3, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no place 3 in sector 1", message);
        }

        [TestMethod]
        public void InsertCar_WrongSector_ShouldNotInsertTheCar()
        {
            var car = new Car("CA1011AH", "John Smith", 1);
            var message = this.park.InsertCar(car, 3, 1, new DateTime(2015, 5, 10, 10, 30, 0));
            Assert.AreEqual("There is no sector 3 in the park", message);
        }
    }
}