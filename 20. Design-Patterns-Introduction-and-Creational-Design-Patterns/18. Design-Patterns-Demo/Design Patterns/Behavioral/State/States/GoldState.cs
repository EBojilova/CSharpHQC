namespace State.States
{
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates an interest bearing state
    /// </remarks>
    /// </summary>
    internal class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            this.Initialize();
        }

        protected override void Initialize()
        {
            this.interest = 0.05;
            this.lowerLimit = 1000.0;
            this.upperLimit = 10000000.0;
        }

        protected override void StateChangeCheck()
        {
            if (this.Balance < 0.0)
            {
                this.Account.State = new RedState(this);
            }
            else if (this.Balance < this.lowerLimit)
            {
                this.Account.State = new SilverState(this);
            }
        }
    }
}