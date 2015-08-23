namespace Builder
{
    using System;

    using Builder.VehicleBuilders;

    internal class Program
    {
        internal static void Main()
        {
            /// ste sazdava otrelnite vehicle v dvijenie s Construct methoda
            var shop = new Shop();

            VehicleBuilder builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            ////builder = new TankBuilder();
            ////shop.Construct(builder);
            ////builder.Vehicle.Show();
        }
    }
}
