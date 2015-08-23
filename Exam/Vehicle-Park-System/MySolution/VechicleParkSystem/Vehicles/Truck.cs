namespace VechicleParkSystem.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal DefaultRegularRate = 4.75M;

        private const decimal DefaultOvertimeRate = 6.20M;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, DefaultRegularRate, DefaultOvertimeRate, reservedHours)
        {
        }
    }
}