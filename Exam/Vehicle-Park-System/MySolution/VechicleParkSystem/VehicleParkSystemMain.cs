namespace VechicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    internal static class VehicleParkSystemMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}