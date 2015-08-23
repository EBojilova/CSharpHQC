namespace State.States
{
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    internal abstract class State
    {
        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;

        public Account Account { get; set; }

        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public virtual void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.StateChangeCheck();
        }

        public virtual void PayInterest()
        {
            this.Balance += this.interest * this.Balance;
            this.StateChangeCheck();
        }

        protected abstract void Initialize();

        protected abstract void StateChangeCheck();
    }
}