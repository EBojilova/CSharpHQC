namespace VechicleParkSystem.Vehicles
{
    internal class Car : Vehicle
    {
        private const decimal DefaultRegularRate = 2.00M;

        private const decimal DefaultOvertimeRate = 3.50M;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, DefaultRegularRate, DefaultOvertimeRate, reservedHours)
        {
        }
    }
}