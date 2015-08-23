namespace Observer.Investors
{
    using System;

    using Observer.Stocks;

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    internal class Investor : IInvestor
    {
        // Bi triabvalo i investitorite da paziat kam koia akcia sa se zakachili
        private readonly string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public Stock Stock { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", this.name, stock.Symbol, stock.Price);
        }
    }
}
