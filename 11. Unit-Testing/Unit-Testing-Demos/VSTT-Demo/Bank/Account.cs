using System;

public class Account
{
    public Account()
    {
        this.Balance = 0;
    }

    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Can not deposit negative or zero amount");
        }

        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Can not withdraw negative or zero amount");
        }

        this.Balance -= amount;
    }

    public void TransferFunds(Account destinationAcc, decimal amount)
    {
        if (destinationAcc == this)
        {
            throw new ArgumentException("Source and destination accounts can not be the same");
        }

        this.Balance -= amount;
        destinationAcc.Balance += amount;
    }

    public void NotCoveredMethod()
    {
        Console.WriteLine("This method is never invoked");
    }
}