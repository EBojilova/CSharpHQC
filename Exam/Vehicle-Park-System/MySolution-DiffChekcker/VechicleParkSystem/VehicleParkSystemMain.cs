namespace VechicleParkSystem
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    internal static class VehicleParkSystemMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            using (var writher = new StreamWriter(@"../../OUTPUT.txt", false))
            {
                Console.SetOut(writher);
                engine.Run();
            }
        }
    }
}