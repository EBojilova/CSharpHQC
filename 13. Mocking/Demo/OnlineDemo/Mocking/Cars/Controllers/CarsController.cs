namespace Cars.Controllers
{
    using System;
    using System.Net.Mail;

    using Cars.Contracts;
    using Cars.Data;
    using Cars.Infrastructure;
    using Cars.Models;

    internal class CarsController
    {
        private const string CarMakePropertyName = "make";

        private const string CarYearPropertyName = "year";

        private readonly ICarRepository carsData;

        public CarsController(CarRepository carsData)
        {
            this.carsData = carsData;
        }

        public CarsController()
            : this(new CarRepository())
        {
        }

        public IView Index()
        {
            var cars = this.carsData.All();
            return new View(cars);
        }

        public IView Add(Car car)
        {
            if (car== null)
            {
                throw new ArgumentNullException("car","Car cannot be null.");
            }

            if (string.IsNullOrEmpty(car.Make)||(string.IsNullOrEmpty(car.Model)))
            {
                throw new ArgumentOutOfRangeException("car", "Car make and model can not be empty.");
            }
            this.carsData.Add(car);
            return this.Details(car.Id);
        }

        public IView Details(int id)
        {
            var car = this.carsData.GetById(id);
            if (car == null)
            {
                throw new ArgumentException("Car cannot be found.", "id");
            }
            return new View(car);
        }
    }
}