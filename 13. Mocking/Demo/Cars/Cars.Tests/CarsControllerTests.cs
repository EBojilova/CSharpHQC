namespace Cars.Tests
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsDataMock;
        private CarsController controller;

        /// <summary>
        /// The agrgument is mock of the real CarsRepository
        /// </summary>
        public CarsControllerTests()
            : this(new CarsRepositoryMock())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsDataMock = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void InitializeCarsController()
        {
            ////this.FakeCarCollection = new List<Car>
            ////  {
            ////      new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
            ////      new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
            ////      new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
            ////      new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            ////  };
            this.controller = new CarsController(this.carsDataMock);
        }

        [TestMethod]
        public void IndexShouldReturnModelWithAllCars()
        {
            ////mockedCarsRepository
            ////   .Setup(r => r.All())
            ////   .Returns(this.FakeCarCollection);
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = null,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = null,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnDetailsModel()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            ////mockedCarsRepository
            ////   .Setup(r => r.Add(It.IsAny<Car>()))
            ////   .Verifiable();
            //// Will returnt the new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 }, from fake colletion.
            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}