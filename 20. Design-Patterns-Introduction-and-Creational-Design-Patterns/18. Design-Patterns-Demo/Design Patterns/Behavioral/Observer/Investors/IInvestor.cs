namespace Observer.Investors
{
    using Observer.Stocks;

    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    internal interface IInvestor
    {
        void Update(Stock stock);
    }
}
