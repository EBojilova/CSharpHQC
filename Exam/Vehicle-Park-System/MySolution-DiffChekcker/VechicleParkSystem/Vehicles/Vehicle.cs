namespace VechicleParkSystem.Vehicles
{
    using System;
    using System.Text.RegularExpressions;

    using VechicleParkSystem.Interfaces;

    internal class Vehicle : IVehicle
    {
        private string licensePlate;

        private decimal overtimeRate;

        private string owner;

        private decimal regularRate;

        private int reservedHours;

        public Vehicle(string licensePlate, string owner, decimal regularRate, decimal overtimeRate, int reservedHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.RegularRate = regularRate;
            this.OvertimeRate = overtimeRate;
            this.ReservedHours = reservedHours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            private set
            {
                if (!Regex.IsMatch(value, @"[A-Z]{1,2}\d{4}[A-Z]{2}"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            private set
            {
                this.ValidateRate("regular", value);
                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            private set
            {
                this.ValidateRate("overtime", value);
                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            // Truck [C5842CH], owned by Jessie Raul
            return string.Format("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
        }

        private void ValidateRate(string name, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format("The {0} rate must be non-negative.", name));
            }
        }
    }
}