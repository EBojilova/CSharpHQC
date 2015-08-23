namespace Observer
{
    using System;
    using System.Runtime.InteropServices.ComTypes;

    using Observer.Investors;
    using Observer.Stocks;

    internal class ObserverMain
    {
        internal static void Main()
        {
            // Create IBM stock and attach investors
            var ibm = new IBM("IBM", 120.00);
            var soros = new Investor("Sorros");
            ibm.Attach(soros);
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors- this is the Observer
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Detach(soros);
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }
    }
}
