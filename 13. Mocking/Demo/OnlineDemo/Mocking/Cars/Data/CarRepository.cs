namespace Cars.Data
{
    using System;

    using Cars.Contracts;
    using Cars.Models;

    internal class CarRepository : ICarRepository
    {
        public CarRepository(IDatabase dataBase)
        {
            this.Data = dataBase;
        }

        public CarRepository()
            : this(new Database())
        {
        }

        public int TotalCars
        {
            get
            {
                return this.Data.Cars.Count;
            }
        }

        protected IDatabase Data { get; set; }

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car", "Cannot add null car.");
            }

            this.Data.Cars.Add(car);
        }

        public void Remove(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car", "Cannot remove null car.");
            }

            this.Data.Cars.Remove(car);
        }
    }
}