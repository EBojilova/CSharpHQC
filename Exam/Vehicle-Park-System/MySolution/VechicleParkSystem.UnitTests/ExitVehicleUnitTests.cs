// ReSharper disable InconsistentNaming
namespace VechicleParkSystem.UnitTests
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VechicleParkSystem.Interfaces;
    using VechicleParkSystem.VehicleParkObjects;
    using VechicleParkSystem.Vehicles;

    [TestClass]
    public class ExitVehicleUnitTests
    {
        private IVehiclePark park;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.park = new VehiclePark(2, 2);
            var car = new Car("CA1011AH", "John Smith", 1);
            this.park.InsertCar(car, 1, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var truck = new Truck("CA1010AH", "Sarah Smith", 1);
            this.park.InsertTruck(truck, 1, 2, new DateTime(2015, 5, 10, 10, 30, 0));

            var motorbike = new Motorbike("CA1012AH", "Linda Smith", 1);
            this.park.InsertMotorbike(motorbike, 2, 1, new DateTime(2015, 5, 10, 10, 30, 0));

            var car2 = new Car("CA1013AH", "Linda Cloe", 1);
            this.park.InsertCar(car2, 2, 2, new DateTime(2015, 5, 10, 10, 30, 0));
        }

        [TestMethod]
        public void ExitCar_CorrectParameters_ShouldExitTheCar()
        {
            var message = this.park.ExitVehicle("CA1011AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendLine("Car [CA1011AH], owned by John Smith")
                .AppendLine("at place (1,1)")
                .AppendLine("Rate: $2.00")
                .AppendLine("Overtime rate: $3.50")
                .AppendLine(new string('-', 20))
                .AppendLine("Total: $5.50")
                .AppendLine("Paid: $50.00")
                .AppendLine("Change: $44.50")
                .Append(new string('*', 20));

            Assert.AreEqual(ticket.ToString(), message);
        }

        [TestMethod]
        public void ExitTruck_CorrectParameters_ShouldExitTheCar()
        {
            var message = this.park.ExitVehicle("CA1010AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendLine("Truck [CA1010AH], owned by Sarah Smith")
                .AppendLine("at place (1,2)")
                .AppendLine("Rate: $4.75")
                .AppendLine("Overtime rate: $6.20")
                .AppendLine(new string('-', 20))
                .AppendLine("Total: $10.95")
                .AppendLine("Paid: $50.00")
                .AppendLine("Change: $39.05")
                .Append(new string('*', 20));

            Assert.AreEqual(ticket.ToString(), message);
        }

        [TestMethod]
        public void ExitMotorbike_CorrectParameters_ShouldExitTheCar()
        {
            var message = this.park.ExitVehicle("CA1012AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendLine("Motorbike [CA1012AH], owned by Linda Smith")
                .AppendLine("at place (2,1)")
                .AppendLine("Rate: $1.35")
                .AppendLine("Overtime rate: $3.00")
                .AppendLine(new string('-', 20))
                .AppendLine("Total: $4.35")
                .AppendLine("Paid: $50.00")
                .AppendLine("Change: $45.65")
                .Append(new string('*', 20));

            Assert.AreEqual(ticket.ToString(), message);
        }

        [TestMethod]
        public void ExitMotorbike_NotExistingVehicle_ShouldExitTheCar()
        {
            var message = this.park.ExitVehicle("CA1018AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);

            Assert.AreEqual("There is no vehicle with license plate CA1018AH in the park", message);
        }

        [TestMethod]
        public void ExitMotorbike_AlreadyExit_ShouldExitTheCar()
        {
            this.park.ExitVehicle("CA1010AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);
            var message = this.park.ExitVehicle("CA1010AH", new DateTime(2015, 5, 10, 12, 30, 0), 50M);

            Assert.AreEqual("There is no vehicle with license plate CA1010AH in the park", message);
        }
    }
}