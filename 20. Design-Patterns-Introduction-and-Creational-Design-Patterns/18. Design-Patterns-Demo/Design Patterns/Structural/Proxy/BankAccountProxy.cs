namespace ProxyPattern
{
    using System;

    ///Implementira sastiat interface kato istinskia BankAccount
    public class BankAccountProxy : IBankAccount
    {
        private readonly bool userIsAuthorized;

        ///Sadarja istinskia BankAccount
        private BankAccount realAccount;

        public BankAccountProxy(string userName, string secretKey)
        {
            // Validate if the user is logged in, if he is legit, if he has rights to see this information and so on...
            if (true)
            {
                this.userIsAuthorized = true;
            }
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 25)
            {
                Console.WriteLine("Minimum deposit amount is 25!");
                return false;
            }

            if (amount > 1000)
            {
                Console.WriteLine("Maximum deposit amount is 1000!");
                return false;
            }

            if (!this.userIsAuthorized)
            {
                Console.WriteLine("You are not authorized!");
                Console.WriteLine("Redirecting you to login screen...");
                return false;
            }

            this.CheckIfAccountIsActive();

            ////Proxy pravi validaciite i chak togava istinskia klas izvarshva realnoto deistvie Deposit
            this.realAccount.Deposit(amount);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Do validations
            this.CheckIfAccountIsActive();

            this.realAccount.Withdraw(amount);
            return true;
        }

        public decimal CurrentBallance()
        {
            // Do validations
            this.CheckIfAccountIsActive();
            return this.realAccount.CurrentBallance();
        }

        private void CheckIfAccountIsActive()
        {
            if (this.realAccount == null)
            {
                this.realAccount = new BankAccount();
            }
        }
    }
}